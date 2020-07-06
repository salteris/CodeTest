using Castle.Core.Logging;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Character : Entity
    {
        public virtual Name Name { get; private set; }

        public virtual int Level { get; private set; }

        public virtual HitPoints HitPoints { get; private set; }

        private readonly List<Class> _classes = new List<Class>();
        public virtual IReadOnlyList<Class> Classes => _classes.ToList();

        public virtual Stats Stats { get; private set; }

        private readonly List<Item> _items = new List<Item>();
        public virtual IReadOnlyList<Item> Items => _items.ToList();

        private readonly List<Defense> _defenses = new List<Defense>();
        public virtual IReadOnlyList<Defense> Defenses => _defenses.ToList();

        protected Character()
        {

        }

        public Character(
            Name name,
            int str,
            int dex,
            int con,
            int wis,
            int _int, 
            int cha)
        {
            Name = name;
            Stats = Stats.SetStats(str, dex, con, wis, _int, cha).Value;
            HitPoints = HitPoints.NewCharacter().Value;
        }

        public void AddClass(Class _class)
        {
            if (_classes.Any(x => x.Name == _class.Name)){
                CalculateNewMaxHitPoints(_class);
                _classes.Find(x => x.Name == _class.Name).AddLevel(_class.ClassLevel);
            } else
            {
                CalculateNewMaxHitPoints(_class);
                _classes.Add(_class);
            }

        }

        public void AddItem(Item item)
        {
            if (item.Modifier.AffectedObject == AffectedObject.Stats && item.Modifier.AffectedValue == "constitution")
                HitPoints.AddToMax((int)Math.Floor((item.Modifier.Value / 2.0)) * Level);

            _items.Add(item);
        }

        public void AddDefense(Defense defense)
        {
            _defenses.Add(defense);
        }

        public void CalculateLevel()
        {
            var classLevels = Classes.Sum(e => e.ClassLevel);

            Level = classLevels;
        }

        public void CalculateNewMaxHitPoints(Class _class)
        {
            var addedCon = 0;
            if(_items != null)
            {
                addedCon = _items.Where(e => e.Modifier.AffectedObject == AffectedObject.Stats && e.Modifier.AffectedValue == "constitution").Sum(e => e.Modifier.Value);
            }
            Random rand = new Random();
            var rolledHp = rand.Next(1, _class.HitDiceValue);

            var conbonus = (int)Math.Floor(((Stats.Constitution + addedCon) - 10) / 2.0);

            var addingHp = (rolledHp + conbonus) * _class.ClassLevel;

            HitPoints.AddToMax(addingHp);
        }

    }
}
