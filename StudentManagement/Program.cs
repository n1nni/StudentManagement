using StudentManagement.Data.Entity;
using StudentManagement.Repository;

#pragma warning disable CS8604, CS8601
namespace StudentManagement
{
    public class Program
    {
        static async Task Main()
        {
            bool TestApp = true;
            StudentRepository studentRepo = new();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to Student Mamagement app, implemented with Entity Framework");
            Console.WriteLine("For now Database is empty.");

            while (TestApp)
            {
                Console.WriteLine("Which Functionality do you want to use: \n'1': CreateStudent" +
                    "\n'2': GetAllStudents\n'3': GetStudentById \n'4': UpdateStudent \n'5': DeleteStudent");
                var number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        Student student = EnterStudentInfo();
                        await studentRepo.CreateStudent(student); 
                        break;
                    case "2":
                        ICollection<Student> students = await studentRepo.GetAllStudents();
                        PrintStudent(students);
                        break;
                    case "3":
                        await Console.Out.WriteLineAsync("Enter the ID of student");
                        var id = int.Parse(Console.ReadLine());
                        Student studentById = await studentRepo.GetStudentById(id);
                        PrintStudent(studentById);
                        break;
                    case "4":
                        await Console.Out.WriteLineAsync("Enter the ID of student in which you wnat to update GPA");
                        var Id = int.Parse(Console.ReadLine());
                        await Console.Out.WriteLineAsync("Enter the new GPA");
                        var gpa = double.Parse(Console.ReadLine());
                        Student updatedStudent = await studentRepo.UpdateStudent(Id, gpa);
                        PrintStudent(updatedStudent);
                        break;
                    case "5":
                        await Console.Out.WriteLineAsync("Enter the ID of student which you want to delete from database");
                        var deleteId = int.Parse(Console.ReadLine());
                        await studentRepo.DeleteStudent(deleteId);
                        break;
                    default:
                        Console.WriteLine("That method doesn.t exsists"); break;
                }
                await Console.Out.WriteLineAsync("Do you want to test again any method (Y/N): ");
                var confirmation = Console.ReadLine()?.Trim().ToLower();

                if (confirmation == "y")
                {
                    TestApp = true;
                }
                else
                {
                    TestApp = false;
                }
            }
        }

        public static Student EnterStudentInfo()
        {
            Student student = new();
            Console.Write("Enter Student's Name: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter Student's LastName: ");
            student.LastName = Console.ReadLine();
            Console.Write("Enter Student's GPA(0-4): ");
            if (double.TryParse(Console.ReadLine(), out double gpa))
            {
                student.GPA = gpa;
            }
            return student;
        }

        public static void PrintStudent(ICollection<Student> students)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Student List");
            foreach (var st in students)
            {
                Console.Write($"Id: { st.Id} \nName: {st.Name} \nLastName: {st.LastName} \nGPA: {st.GPA}");
                Console.WriteLine("\n");
            }
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public static void PrintStudent(Student student)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Student with {student.Id}");
            Console.WriteLine($"Id: {student.Id} \nName: {student.Name} \nLastName: {student.LastName} \nGPA: {student.GPA}\n");
            Console.ForegroundColor = ConsoleColor.Red;
        }

    }
}