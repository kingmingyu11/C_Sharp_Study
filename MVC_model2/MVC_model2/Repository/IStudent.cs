using MVC_model2.Models;
using System.ComponentModel;

namespace MVC_model2.Repository
{
    public interface IStudent
    {
        //만들고자 하는기능 !!!
        List<StudentModel> GetAllStudents();
        //1.전체검색
        //2.특정 ID만 검색하고 싶어
        StudentModel getStudentById(int id);
    }
}
