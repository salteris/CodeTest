using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Threading.Tasks;
using CodeTest.Domain;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace CodeTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeTestController : ControllerBase
    {

        private readonly CodeTestContext _context;
        private readonly ILogger<CodeTestController> _logger;
        private readonly CharacterRepository _repository;

        public CodeTestController(ILogger<CodeTestController> logger, CodeTestContext context)
        {
            _context = context;
            _logger = logger;
            _repository = new CharacterRepository(_context);
        }

        [HttpPost("Create Character")]
        public IActionResult CreateCharacter([FromBody]CharacterCreateInputDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Result<Name> nameResult = Name.Create(input.PlayerName, input.CharacterName);
            if (nameResult.IsFailure)
                return BadRequest(nameResult.Error);

            if(_context.Characters.Any(x => (x.Name.CharacterName == nameResult.Value.CharacterName && x.Name.PlayerName == nameResult.Value.PlayerName)))
            {
                return BadRequest("The Player already has a Character with that name.");
            }

            var character = new Character(nameResult.Value, input.Strength, input.Dexterity, input.Constitution, input.Wisdom, input.Intelligence, input.Charisma);

            _repository.Save(character);

            _context.SaveChanges();

            return Ok(character);
        }

        [HttpGet("Get Character")]
        public IActionResult GetCharacter([FromQuery]long characterId)
        {
            var character = _repository.GetById(characterId);
            if (character == null)
                return BadRequest("Character does not exist.");

            return Ok(character);
        }

        [HttpPost("Add Class")]
        public IActionResult AddClass([FromBody]AddClassInputDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (input.ClassLevel < 1)
                return BadRequest("New Class level must be greater than 0.");

            var character = _repository.GetById(input.CharacterId);
            if (character == null)
                return BadRequest("Character does not exist");

            var _class = new Class(
                input.Name,
                input.ClassLevel
                );

            character.AddClass(_class);

            character.CalculateLevel();

            _context.SaveChanges();

            return Ok(character);
        }

        [HttpPost("Add Item to Character")]
        public IActionResult AddItem([FromBody]AddItemInputDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Item item = new Item(input.ItemName, input.AffectedObject, input.AffectedValue, input.Value);

            var character = _repository.GetById(input.CharacterId);
            if (character == null)
                return BadRequest("Character does not exist.");

            if (character.Items.Any(x => x.Name == item.Name))
                return BadRequest("Character already has this item.");

            character.AddItem(item);

            _context.SaveChanges();

            return Ok(character);
        }

        [HttpPost("Add Defense to Character")]
        public IActionResult AddDefense([FromBody]AddDefenseInputDTO input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ProtectionType damageType = ProtectionType.Resistant;
            if (input.Protection == "immune")
                damageType = ProtectionType.Immune;

            Defense defense = new Defense(input.Type, damageType);

            var character = _repository.GetById(input.CharacterId);
            if (character == null)
                return BadRequest("Character does not exist.");

            if (character.Defenses.Any(x => x.Protection == defense.Protection && x.Type == defense.Type))
                return BadRequest("Character already has this defense.");

            character.AddDefense(defense);

            _context.SaveChanges();

            return Ok(character);

        }

        [HttpGet("Deal Damage To Character")]
        public IActionResult DealDamage([FromQuery]int characterId, [FromQuery]int damage, [FromQuery] string type)
        {
            if (damage < 0)
                return BadRequest("Damage must be positive.");

            var character = _repository.GetById(characterId);
            if (character == null)
                return BadRequest("Character does not exist.");

            if (character.Defenses.Any(x => x.Type == type))
            {
                if (character.Defenses.Any(x => x.Protection == ProtectionType.Immune && x.Type == type))
                    return Ok(character);

                if (character.Defenses.Any(x => x.Protection == ProtectionType.Resistant))
                    damage = (int)Math.Floor((double)damage / 2);
            }

            character.HitPoints.TakeDamage(damage);

            _context.SaveChanges();

            return Ok(character);
        }

        [HttpGet("Heal Character")]
        public IActionResult Heal([FromQuery]int characterId, [FromQuery]int healing)
        {
            if (healing < 0)
                return BadRequest("Healing must be positive.");

            var character = _repository.GetById(characterId);
            if (character == null)
                return BadRequest("Character does not exist.");

            character.HitPoints.Heal(healing);

            _context.SaveChanges();

            return Ok(character);
        }

        [HttpGet("Add Temp hit points to Character")]
        public IActionResult AddTemp([FromQuery]int characterId, [FromQuery]int temp)
        {
            if (temp < 0)
                return BadRequest("Healing must be positive.");

            var character = _repository.GetById(characterId);
            if (character == null)
                return BadRequest("Character does not exist.");

            character.HitPoints.AddTemp(temp);

            _context.SaveChanges();

            return Ok(character);
        }

        [HttpGet("Reset Characters' Hitpoints")]
        public IActionResult ResetHitPoints([FromQuery]int characterId)
        {
            var character = _repository.GetById(characterId);
            if (character == null)
                return BadRequest("Character does not exist.");

            character.HitPoints.ResetHitPoints();

            _context.SaveChanges();

            return Ok(character);
        }
    }
}
