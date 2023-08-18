#pragma warning disable CS8618

namespace StudentManagement.Data.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public double GPA { get; set; }
    }
}
