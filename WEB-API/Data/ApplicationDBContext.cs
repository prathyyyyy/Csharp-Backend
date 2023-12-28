using Microsoft.EntityFrameworkCore;
using WorldAPI.Models;

namespace WorldAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> db) : base(db)
        {

        }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<State> State { get; set; }
    }
}
