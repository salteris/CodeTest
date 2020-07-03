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
            if(Temp > 0)
            {
                Temp -= damage;
            }

            if (Temp < 0)
            {
                Current += Temp;
                Temp = 0;
                if (Current < 0)
                    Current = 0;
            }
            else 
            {
                Current -= damage;
                if (Current < 0)
                    Current = 0;
            }
        }

        public void Heal(int healing)
        {
            Current += healing;
            if (Current > Max)
                Current = Max;
        }

        public void AddTemp(int temp)
        {
            Temp = temp;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Current;
            yield return Max;
        }
    }
}
