using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeFightAPI.Models;

namespace WeFightAPI.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly CharacterContext _context;

        public CharacterRepository(CharacterContext context)
        {
            this._context = context;
        }

        public async Task<Character> Create(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task Delete(int id)
        {
            Character characterToDelete = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(characterToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> Get()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> Get(int id)
        {
            return await _context.Characters.FindAsync(id);
        }

        public async Task Update(Character character)
        {
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
