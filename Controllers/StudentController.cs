using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Student_NetCore.Model;
using WebApi_Student_NetCore.Repository;

namespace WebApi_Student_NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        Studentrepo rp = new Studentrepo();

        [HttpPost]

        public int insertstudent(Student std)
        {

            int count =rp.insertstudent(std);
            return count;
        }


        [HttpPut]

        public int updatestudent(Student std)
        {

            int count = rp.UpdateStudent(std);
            return count;
        }


        [HttpDelete]
        public int deletestudent(int id) 
        {
            int count = rp.deleteStudent(id);
            return count;
        
        }


        [HttpGet]

        public Student GetStudentById(int id)
        {
            Student std = rp.GetStudentById(id);
            return std;
        }


        [HttpGet ("GetallStudent")]

        public List<Student> GetallStudent() 
        {
            List<Student> st=rp.GetAllStudents();
            return st;
        }


    }
}
