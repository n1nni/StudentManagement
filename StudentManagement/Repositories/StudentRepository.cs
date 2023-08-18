using Microsoft.EntityFrameworkCore;
using StudentManagement.Data.Context;
using StudentManagement.Data.Entity;
using StudentManagement.Repository.IRepository;
#pragma warning disable CS8603, CS8602

namespace StudentManagement.Repository
{
    public class StudentRepository : IStudentRepository
    {

        public async Task CreateStudent(Student student)
        {
            try
            {
                using var context = new ApplicationDbContext();
                await context.Students.AddAsync(student);

                await context.SaveChangesAsync();
                
                await Console.Out.WriteLineAsync("Student added Successfully");
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
        public async Task<ICollection<Student>> GetAllStudents()
        {
            try
            {
                using var context = new ApplicationDbContext();
                ICollection<Student> students =  await context.Students.ToListAsync();
                return students;
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = new Student();
            try
            {
                using var context = new ApplicationDbContext();
                student = await context.Students.FindAsync(id);
                return student;
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return student;
            }
        }

        public async Task<Student> UpdateStudent(int id, double gpa)
        {
            var student = new Student();

            try
            {
                using var context = new ApplicationDbContext();
                student = await context.Students.FindAsync(id);
                await Console.Out.WriteLineAsync($"students GPA with ID {id} was {student.GPA}, now student's Info is: ");
                student.GPA = gpa;
                context.SaveChanges();
                return student;

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return student;
            }
        }

        public async Task DeleteStudent(int id)
        {
            try
            {
                using var context = new ApplicationDbContext();
                var student = await context.Students.FindAsync(id);

                if (student == null)
                {
                    await Console.Out.WriteLineAsync($"Student with ID {id} not found.");
                    return;
                }
                await Console.Out.WriteLineAsync($"Confirm deletion of student with ID {id} (Y/N): ");
                var confirmation = Console.ReadLine()?.Trim().ToLower();

                if (confirmation == "y")
                {
                    context.Students.Remove(student);
                    await context.SaveChangesAsync();
                    await Console.Out.WriteLineAsync($"Student with ID {id} deleted successfully.");
                }
                else
                {
                    await Console.Out.WriteLineAsync($"Deletion of student with ID {id} cancelled.");
                }

            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

        }
    }
}
