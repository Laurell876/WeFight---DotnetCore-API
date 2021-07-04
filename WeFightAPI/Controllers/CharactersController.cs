using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeFightAPI.Models;
using WeFightAPI.Repositories;

namespace WeFightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {
            this._characterRepository = characterRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Character>> GetCharacters()
        {
            return await _characterRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacters(int id)
        {
            return await _characterRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacters([FromBody] Character character)
        {
            Character newCharacter = await _characterRepository.Create(character);
            return CreatedAtAction(nameof(GetCharacters), new { id = newCharacter.Id }, newCharacter);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutCharacter(int id, [FromBody] Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            await _characterRepository.Update(character);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Character characterToDelete = await _characterRepository.Get(id);
            if (characterToDelete == null)
                return NotFound();

            await _characterRepository.Delete(characterToDelete.Id);
            return NoContent();
        }
    }
}
