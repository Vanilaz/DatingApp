using Dating.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dating.Api.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> AppUsers { get; set; }
    }
}