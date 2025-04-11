using Microsoft.EntityFrameworkCore;
using shiremind.Models.Common;

namespace shiremind.Data
{
    public class ShireMindDbContext : DbContext
    {
        public ShireMindDbContext(DbContextOptions<ShireMindDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}