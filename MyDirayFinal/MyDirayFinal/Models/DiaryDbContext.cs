using Microsoft.EntityFrameworkCore;

namespace MyDirayFinal.Models
{
    public class DiaryDbContext : DbContext
    {
        public DiaryDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Diary> Diary { get; set; }
    }
}
