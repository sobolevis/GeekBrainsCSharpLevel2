using System.Windows;
using System.Windows.Controls;

namespace Lesson5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IDataBase
    {
        public ComboBox ComboBox { get => DepartmentsComboBox; set => DepartmentsComboBox = value; }
        public ListView ListView { get => EmployeeListView; set => EmployeeListView = value; }
        public string NewDepartment { get => NewDepartmentTextBox.Text; set => NewDepartmentTextBox.Text = value; }
        public string FirstName { get => FirstNameTextBox.Text; set => FirstNameTextBox.Text = value; }
        public string SecondName { get => SecondNameTextBox.Text; set => SecondNameTextBox.Text = value; }
        public string Age { get => AgeTextBox.Text; set => AgeTextBox.Text = value; }
        public string Department { get => DepartmentTextBox.Text; set => DepartmentTextBox.Text = value; }
        public string Post { get => PostTextBox.Text; set => PostTextBox.Text = value; }
        public string Phone { get => PhoneTextBox.Text; set => PhoneTextBox.Text = value; }

        private readonly DataBase _dataBase;

        public MainWindow()
        {
            InitializeComponent();
            _dataBase = new DataBase(this);
        }
        
        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            _dataBase.AddDepartment();
        }

        private void DepartmentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _dataBase.DepartmentSelected();
        }

        private void EmployeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _dataBase.EmployeeSelect();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            _dataBase.AddEmployee();
        }

        private void ChangeEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            _dataBase.ChangeEmployee();
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            _dataBase.DeleteEmployee();
        }
    }
}
