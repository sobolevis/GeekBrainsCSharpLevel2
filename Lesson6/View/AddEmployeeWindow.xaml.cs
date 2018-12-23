using System.Collections.ObjectModel;
using System.Windows;
using Lesson6.Model;

namespace Lesson6.View
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        private ObservableCollection<Department> _departments;
        private ObservableCollection<Employee> _employees;

        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        public AddEmployeeWindow(ObservableCollection<Department> departments, ObservableCollection<Employee> employees) : this()
        {
            _departments = departments;
            _employees = employees;
        }

        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Department department = null;
            foreach (var dep in _departments)
            {
                if (dep.Name == EmployeeDepartment.Text)
                {
                    department = dep;
                    break;
                }
            }

            if (department != null)
            {
                _employees.Add(new Employee(EmployeeName.Text, EmployeeSurname.Text,
                    EmployeeDepartment.Text, EmployeePost.Text, EmployeePhone.Text));
                MessageBox.Show("Сотрудник добавлен", "Успех",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
                MessageBox.Show("Департамент не существует!", "Ошибка!", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Отменить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
