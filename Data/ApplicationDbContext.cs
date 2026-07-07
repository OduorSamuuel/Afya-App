using AfyaApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AfyaApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
