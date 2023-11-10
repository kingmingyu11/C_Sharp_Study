using MVC_model2.Models;

namespace MVC_model2.Repository
{
    public class StudentRepository : IStudent
    {
        public List<StudentModel> GetAllStudents()
        {
            return DataSource();
             
        }

        private List<StudentModel> DataSource()
        {
            var students = new List<StudentModel>()
            {
                new StudentModel{ ID=1, Name= "홍길동", HP = "010-1111-1111", Major = "컴공" },
                new StudentModel{ ID=1, Name= "이순신", HP = "010-2222-2222", Major = "정통" },
                new StudentModel{ ID=1, Name= "강감찬", HP = "010-3333-3333", Major = "기계" }
            };
            return students;
        }

        public StudentModel getStudentById(int id)
        {
            return DataSource().Where(x=>x.ID==id).FirstOrDefault();
        }
    }
}
