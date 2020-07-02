using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Class : Entity
    {
        public string Name { get; }
        public int HitDiceValue { get; }
        public int ClassLevel { get; private set; }
        [JsonIgnore]
        public virtual Character Character { get; }


        protected Class()
        {

        }

        public Class(
                string name,
                int classLevel
            ): this()
        {
            Name = name;
            switch (name) 
            {
                case "Fighter": 
                    HitDiceValue = 10;
                    break;
                case "Cleric":
                    HitDiceValue = 8;
                    break;
                case "Bard":
                    HitDiceValue = 8;
                    break;
                case "Druid":
                    HitDiceValue = 8;
                    break;
                case "Monk":
                    HitDiceValue = 8;
                    break;
                case "Paladin":
                    HitDiceValue = 10;
                    break;
                case "Ranger":
                    HitDiceValue = 10;
                    break;
                case "Rogue":
                    HitDiceValue = 8;
                    break;
                case "Sorcerer":
                    HitDiceValue = 6;
                    break;
                case "Warlock":
                    HitDiceValue = 8;
                    break;
                case "Wizard":
                    HitDiceValue = 6;
                    break;
                case "Barbarian":
                    HitDiceValue = 12;
                    break;
                default:
                    break;
            }

            ClassLevel = classLevel;
        }

        public void AddLevel(int level)
        {
            ClassLevel+=level;
        }
    }
}
