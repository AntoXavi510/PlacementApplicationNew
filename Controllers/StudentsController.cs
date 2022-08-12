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

            await placement.AddNewStudent(student);
            return CreatedAtAction("GetStudent", new { id = student.UserId }, student);
        }
        [Route("[action]")]
        [HttpPost]     
        public ActionResult<Student> Login(Student student)
        {
           var p= placement.Login(student);
            // return CreatedAtAction("GetStudent", new { id = student.UserId }, student);
            return p;
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            placement.DeleteStudent(id);
            return Ok(placement);
        }

      
    }
}
