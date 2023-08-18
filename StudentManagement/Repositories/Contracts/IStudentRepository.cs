using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Entity;

namespace StudentManagement.Repository.IRepository
{
    public interface IStudentRepository
    {
        public Task CreateStudent(Student student);
        public Task<ICollection<Student>> GetAllStudents();
        public Task<Student> GetStudentById(int id);
        public Task<Student> UpdateStudent(int id, double gpa);
        public Task DeleteStudent(int id);


    }
}
