using System.Windows.Controls;

namespace Lesson5
{
    interface IDataBase
    {
        ComboBox ComboBox { get; set; }
        ListView ListView { get; set; }
        string NewDepartment { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string Age { get; set; }
        string Department { get; set; }
        string Post { get; set; }
        string Phone { get; set; }
    }
}
