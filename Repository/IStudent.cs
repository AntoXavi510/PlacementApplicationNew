using PlacementApplicationNew.Model;

namespace PlacementApplicationNew.Repository
{
    public interface IStudent
    {
        public Task<List<Student>> GetStudents();
        public Task<Student> GetStudent(int id);
        public Task<Student> Login(Student student);
        public Task<Student> AddNewStudent(Student student);
        public Task<Student> UpdateStudent(Student student);
        public Task<Student> SearchForm();
        public Task<List<Student>> SearchResult();
        public void DeleteStudent(int id);
        public bool StudentExists(int id);
       
    }
}
