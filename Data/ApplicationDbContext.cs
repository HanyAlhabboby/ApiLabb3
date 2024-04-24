using ApiLabb3.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLabb3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }

        public DbSet<Link> Links { get; set; }

    }
}
