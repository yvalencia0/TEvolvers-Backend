using Microsoft.EntityFrameworkCore;
using TEvolvers.Models;

namespace TEvolvers.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
