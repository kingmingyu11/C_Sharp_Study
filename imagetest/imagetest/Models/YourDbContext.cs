using Microsoft.EntityFrameworkCore;

namespace imagetest.Models
{
    public class YourDbContext:DbContext
    {
        public YourDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ImageEntity> Images { get; set; }
    }
}
