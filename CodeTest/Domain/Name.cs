using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public class Name : ValueObject
    {
        public string PlayerName { get; }
        public string CharacterName { get; }

        protected Name()
        {
        }

        private Name(string player, string character)
            : this()
        {
            PlayerName = player;
            CharacterName = character;
        }

        public static Result<Name> Create(string player, string character)
        {
            if (string.IsNullOrWhiteSpace(player))
                return Result.Failure<Name>("Player name should not be empty");
            if (string.IsNullOrWhiteSpace(character))
                return Result.Failure<Name>("Character name should not be empty");

            player = player.Trim();
            character = character.Trim();

            if (player.Length > 200)
                return Result.Failure<Name>("Player name is too long");
            if (character.Length > 200)
                return Result.Failure<Name>("Character name is too long");

            return Result.Success(new Name(player, character));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PlayerName;
            yield return CharacterName;
        }
    }
}
