using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeFightAPI.Models;

namespace WeFightAPI.Repositories
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> Get();
        Task<Character> Get(int id);
        Task<Character> Create(Character character);
        Task Update(Character character);
        Task Delete(int id);
    }
}
