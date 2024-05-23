using Microsoft.EntityFrameworkCore;
using LMS.Domain.Entities;

namespace LMS.Infrastructure.Data
{
    public class LMSDbContext : DbContext
    {
        public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
