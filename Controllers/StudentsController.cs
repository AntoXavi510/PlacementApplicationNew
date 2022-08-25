using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacementApplicationNew.Model;
using PlacementApplicationNew.Repository;
namespace PlacementApplicationNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudent placement;

        public StudentsController(IStudent _placement)
        {
            placement = _placement;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await placement.GetStudents();
        }
        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            //if (placement.GetStudent(id) == null)
            //{
            //    return NotFound();
            //}
            //  var student = await placement.GetStudent(id);

            //  if (student == null)
            //  {
            //      return NotFound();
            //  }

            return await placement.GetStudent(id);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            await placement.UpdateStudent(student);
            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            if (await placement.AddNewStudent(student) == null)
            {
                return BadRequest();
            }
            else { return Accepted(); }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<Student>> Login(Student student)
        {

            if (await placement.Login(student) == null)
            { return BadRequest(); }
            else { return await placement.Login(student); }
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            placement.DeleteStudent(id);
            return NoContent();
        }

        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> GetStudent(int id)
        //    {

        //    }
        //}
    }
}
