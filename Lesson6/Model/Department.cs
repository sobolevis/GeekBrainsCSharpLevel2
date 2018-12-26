namespace Lesson6.Model
{
    public class Department
    {
        public string Name { get; set; }
        public string Floor { get; set; }

        public Department(string name, string floor)
        {
            Name = name;
            Floor = floor;
        }
    }
}
