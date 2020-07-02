using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class HitPoints : ValueObject
    {
        public int Current { get; private set; }
        public int Max { get; private set; }
        public int Temp { get; private set; }

        protected HitPoints ()
        {

        }

        private HitPoints(int current, int max, int temp)
            : this()
        {
            Current = current;
            Max = max;
            Temp = temp;
        }

        public static Result<HitPoints> NewCharacter()
        {
            return Result.Success(new HitPoints(0, 0, 0));
        }

        public void AddToMax(int newHitPoints)
        {
            Max += newHitPoints;
        }

        public void ResetHitPoints()
        {
            Current = Max;
        }

        public void AddTempHitPoints(int temp)
        {
            Temp = temp;
        }

        public void TakeDamage(int damage)
        {
            int newDamage = 0;
            if(Temp > 0)
            {
                newDamage = damage - Temp;
            }

            if (newDamage > 0)
            {
                Temp -= damage;
            } else
            {
                Temp = 0;
                Current -= newDamage;
                if (Current < 0)
                    Current = 0;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Current;
            yield return Max;
        }
    }
}
