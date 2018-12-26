namespace Lesson6.Model
{
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Department { get; set; }
        public string Post { get; set; }
        public string Phone { get; set; }

        public Employee(string name, string surname, string department, string post, string phone)
        {
            Name = name;
            Surname = surname;
            Department = department;
            Post = post;
            Phone = phone;
        }
    }
}
