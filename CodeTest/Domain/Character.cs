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

        private readonly List<Class> _classes = new List<Class>();
        public virtual IReadOnlyList<Class> Classes => _classes.ToList();

        //private readonly List<Stat> _stats = new List<Stat>();
        //public virtual IReadOnlyList<Stat> Stats => _stats.ToList();

        //private readonly List<Item> _items = new List<Item>();
        //public virtual IReadOnlyList<Item> Items => _items.ToList();

        //private readonly List<Defense> _defenses = new List<Defense>();
        //public virtual IReadOnlyList<Defense> Defenses => _defenses.ToList();

        protected Character()
        {

        }

        public Character(
            Name name)
        {
            Name = name;
        }

        public Result<int> AddClass(Class _class)
        {
            if (_classes.Any(x => x.Name == _class.Name)){
                _classes.Find(x => x.Name == _class.Name).AddLevel();
            } else
            {
                _classes.Add(_class);
            }

            return Result.Success(_classes.Find(x => x.Name == _class.Name).ClassLevel);
        }

        public Result<int> GetHitPoints()
        {
            if (_classes.Count() == 0)
                return Result.Failure<int>("Character has no classes");

            //return _classes.Select(x => x.HitDiceValue)
            return Result.Success(10);
        }
    }
}
