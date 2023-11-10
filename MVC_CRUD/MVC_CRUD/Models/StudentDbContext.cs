using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

namespace MVC_CRUD.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options) 
        { }
        //생성자 DB연걸 초기화
        public DbSet<Student> Student { get; set; }

    }
    //DB연결 작업 -----> appsettings.json
    //테이블 만들기

}
