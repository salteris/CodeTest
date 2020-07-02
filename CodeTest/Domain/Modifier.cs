using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Modifier : ValueObject
    {
        public AffectedObject AffectedObject { get; }
        public string AffectedValue { get; }
        public int Value { get; }

        protected Modifier()
        {

        }

        private Modifier(
            AffectedObject affectedObject,
            string affectedValue,
            int value
            )
        {
            AffectedObject = affectedObject;
            AffectedValue = affectedValue;
            Value = value;
        }

        public static Result<Modifier> AddModifier (AffectedObject affectedObject, string affectedValue, int value)
        {
            if (affectedValue == null)
                return Result.Failure<Modifier>("Modifier affected value must be named.");

            return Result.Success(new Modifier(affectedObject, affectedValue, value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return AffectedObject;
            yield return AffectedValue;
            yield return Value;
        }
    }

    public enum AffectedObject
    {
        Stats = 1
    }
}
