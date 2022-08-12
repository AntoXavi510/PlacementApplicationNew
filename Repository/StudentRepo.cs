using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlacementApplicationNew.Model;

namespace PlacementApplicationNew.Repository
{
    public class StudentRepo : IStudent
    {
        private readonly PlacementAppContext _context;
        public StudentRepo(PlacementAppContext context)
        {
            _context = context;
        }


        public async Task<Student> AddNewStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public void DeleteStudent(int id)
        {
            Student student = _context.Students.Find(id);
            _context.Remove(student);
              _context.SaveChanges();
           
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
        }


        
        public async Task<List<Student>> GetStudents()
        {
                return await _context.Students.ToListAsync(); 
            
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

       public  bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.UserId == id)).GetValueOrDefault();
        }

        public Student Login(Student student)
        {
                var result = (from i in _context.Students where i.Password == student.Password && i.UserId == student.UserId select i).SingleOrDefault();
            try
            {
                if (result != null)
                {
                    return student;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) {
                throw;
            }
            return student;
        }
        

        //public async Task<Student> Login(Student student)
        //{
        //    var result = (from i in _context.Students where i.UserId == student.UserId && i.Password == student.Password select i).FirstOrDefault();
        //    return await Task.FromResult(result);

        //}
    }
}
