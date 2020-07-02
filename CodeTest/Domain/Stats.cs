using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Stats : ValueObject
    {
        public int Strength { get;  }
        public int Dexterity { get;  }
        public int Constitution { get;  }
        public int Wisdom { get;  }
        public int Intelligence { get;  }
        public int Charisma { get;  }

        protected Stats()
        {
            
        }

        private Stats(
            int strength,
            int dexterity,
            int constitution,
            int wisdom,
            int intelligence,
            int charisma
            )
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Wisdom = wisdom;
            Intelligence = intelligence;
            Charisma = charisma;
        }

        public static Result<Stats> SetStats(int str, int dex, int con, int wis, int _int, int cha)
        {
            if (str < 0 || dex < 0 || con < 0 || wis < 0 || _int < 0 || cha < 0)
                return Result.Failure<Stats>("No character stats can be below 0.");

            return Result.Success(new Stats(str, dex, con, wis, _int, cha));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Strength;
            yield return Dexterity;
            yield return Constitution;
            yield return Wisdom; 
            yield return Intelligence;
            yield return Charisma;
        }
    }
}
