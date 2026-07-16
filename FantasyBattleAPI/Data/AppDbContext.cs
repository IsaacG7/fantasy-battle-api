using FantasyBattleAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace FantasyBattleAPI.Data

{
    public class AppDbContext : DbContext
    {
        public DbSet<Character> characters { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions) { }


    }
}
