using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Saad.Models.Entity;



namespace WebApplication_Empty.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }


        public DbSet<User> users { get; set; }

    }
}