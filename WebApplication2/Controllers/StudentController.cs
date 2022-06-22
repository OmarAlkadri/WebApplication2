using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Core.Interfaces;
using WebApplication2.Core.Entities;

namespace OnlineShoppingCenterproject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        public StudentController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet("AllStudent")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudent()
        {
            try
            {
                var entity = await _repository.Student.GetAllStudent();
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string? id, StudentForUpdateDto? students)
        {
            if (students == null)
                return BadRequest("Castomer object is null");

            if (!ModelState.IsValid)
                return BadRequest("Invalid model object");

            Guid  ID = new Guid(id);
            var student = await _repository.Student.GetStudentById(ID);

            if (students.Name != null)
                student.Name = students.Name;
            if (students.LastName != null)
                student.LastName = students.LastName;
            if (students.Vize != null)
                student.Vize = students.Vize; 
            if (students.Final != null)
                student.Final = students.Final;

            _repository.Student.Update(student);
            _repository.Save();
            return NoContent();
        }


        [HttpPost("Add")]
        public async Task<IActionResult> RegisterStudent(StudentForUpdateDto? student)
        {

            if (student == null || !ModelState.IsValid)
                return BadRequest();
            Student add = new Student();
            add.Name = student.Name;
            add.Vize = student.Vize;
            add.Final = student.Final;
            add.LastName = student.LastName;
            _repository.Student.Add(add);
            _repository.Save();
            return Ok();//CreatedAtAction("GetUserById", new { id = add.Id }, add);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid Id)
        {
            try
            {
                var Student = await _repository.Student.GetStudentById(Id);
                if (Student == null)
                {
                    return NotFound();
                }
                _repository.Student.Delete(Student);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error {ex}");
            }
        }
    }
}
