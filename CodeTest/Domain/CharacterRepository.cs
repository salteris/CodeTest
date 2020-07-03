using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CodeTest.Domain
{
    public sealed class CharacterRepository
    {
        private readonly CodeTestContext _context;

        public CharacterRepository(CodeTestContext context)
        {
            _context = context;
        }

        public Character GetById (long characterId)
        {
            Character character = _context.Characters.Find(characterId);

            if (character == null)
                return null;

            _context.Entry(character).Collection(x => x.Classes).Load();
            _context.Entry(character).Collection(x => x.Defenses).Load();
            _context.Entry(character).Collection(x => x.Items).Load();

            return character;
        }

        public void Save(Character character)
        {
            _context.Characters.Attach(character);
        }
    }
}
