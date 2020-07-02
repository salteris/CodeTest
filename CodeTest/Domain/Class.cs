using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Class : Entity
    {
        public ClassName Name { get; }
        public DiceValue HitDiceValue { get; }
        public int ClassLevel { get; private set; }
        public virtual Character Character { get; }


        protected Class()
        {

        }

        public Class(
                ClassName name,
                DiceValue hitDiceValue,
                int classLevel
            ): this()
        {
            Name = name;
            HitDiceValue = hitDiceValue;
            ClassLevel = classLevel;
        }

        public void AddLevel()
        {
            ClassLevel++;
        }
    }

    public enum ClassName
    {
        Fighter = 0,
        Cleric = 1,
        Bard = 2,
        Druid = 3,
        Ranger = 4,
        Sorcerer = 5,
        Warlock = 6,
        Wizard = 7,
        Barbarian = 8
    }

    public enum DiceValue
    {
        d4 = 4,
        d6 = 6,
        d8 = 8,
        d10 = 10,
        d12 = 12
    }
}
