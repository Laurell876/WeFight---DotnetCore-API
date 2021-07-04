using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeFightAPI.Models
{
    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Character> Characters { get; set; }
    }
}
