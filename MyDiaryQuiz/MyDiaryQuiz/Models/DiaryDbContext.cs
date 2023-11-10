using Microsoft.EntityFrameworkCore;

namespace MyDiaryQuiz.Models
{
    public class DiaryDbContext :DbContext

    {
        public DiaryDbContext(DbContextOptions options) : base(options)
        {
           
        

        }


        //생성자 DB연결 초기화
        public DbSet<Diary> Diary { get; set; }
    }
}
