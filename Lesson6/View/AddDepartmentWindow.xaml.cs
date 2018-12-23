using System.Collections.ObjectModel;
using System.Windows;
using Lesson6.Model;

namespace Lesson6.View
{
    /// <summary>
    /// Логика взаимодействия для AddDepartmentWindow.xaml
    /// </summary>
    public partial class AddDepartmentWindow : Window
    {
        private ObservableCollection<Department> _departments;

        public AddDepartmentWindow()
        {
            InitializeComponent();
        }

        public AddDepartmentWindow(ObservableCollection<Department> departments) : this()
        {
            _departments = departments;
        }

        /// <summary>
        /// Добавить департамент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Department department = null;
            foreach (var dep in _departments)
            {
                if (dep.Name == DepartmentName.Text)
                {
                    department = dep;
                    break;
                }
            }

            if (department == null)
            {
                _departments.Add(new Department(DepartmentName.Text, DepartmentFloor.Text));
                MessageBox.Show("Департамент добавлен", "Успех", 
                                MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
                MessageBox.Show("Департамент уже существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
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
