using System;
using System.Collections.Generic;
using System.Linq;
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

        public CodeTestController(ILogger<CodeTestController> logger, CodeTestContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult CreateCharacter(string playerName, string characterName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Result<Name> nameResult = Name.Create(playerName, characterName);
            if (nameResult.IsFailure)
                return BadRequest(nameResult.Error);

            var character = new Character(nameResult.Value);

            return Ok(character);
        }
    }
}
