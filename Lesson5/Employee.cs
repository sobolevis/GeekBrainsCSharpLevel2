namespace Lesson5
{
    class Employee
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Age { get; set; }
        public string Department { get; set; }
        public string Post { get; set; }
        public string Phone { get; set; }

        public Employee(string firstName, string secondName, string age, string department, string post, string phone)
        {
            FirstName = firstName;
            SecondName = secondName;
            Age = age;
            Department = department;
            Post = post;
            Phone = phone;
        }

    }
}
