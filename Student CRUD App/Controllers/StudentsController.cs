using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Student_CRUD_App.Repository;
using Student_CRUD_App.StudentModel;

namespace Student_CRUD_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentRepository _studentRepository;
        public StudentsController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("Get All")]
        public IActionResult Get()
        {
            return Ok(_studentRepository.GetAllStudents());
        }

        [HttpPost("Create")]
        public IActionResult Post(Student student)
        {
            _studentRepository.InsertStudent(student);
            return Ok("Student inserted successfully");
        }

        [HttpPut("Update")]
        public IActionResult Put(Student student)
        {
            _studentRepository.UpdateStudent(student);
            return Ok("Student updated successfully");
        }

        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id)
        {
            _studentRepository.DeleteStudent(id);
            return Ok("Student deleted successfully");
        }


    }
}
