using System.Collections.Generic;
using System.Windows;

namespace Lesson5
{
    class DataBase
    {
        private IDataBase _dataBase;
        private List<Department> _departments;

        private Department _currentDepartment;
        private Employee _currentEmployee;

        public DataBase(IDataBase dataBase)
        {
            _dataBase = dataBase;
            _departments = new List<Department>();
            Init();
        }

        /// <summary>
        /// Инициализация, создание "базы данных"
        /// </summary>
        private void Init()
        {
            _departments.Add(new Department("Development"));
            _departments.Add(new Department("Human Resources"));
            _departments.Add(new Department("Financial"));

            _departments[0].Employees.Add(new Employee("Igor", "Petrov", "31", "Development", "Head", "8-999-777-66-55"));
            _departments[0].Employees.Add(new Employee("Artem", "Smirnov", "27", "Development", "Team Lead", "8-111-222-33-44"));
            _departments[0].Employees.Add(new Employee("Dmitriy", "Vasilev", "22", "Development", "Developer", "8-333-888-55-77"));
            _departments[0].Employees.Add(new Employee("Pavel", "Kravin", "24", "Development", "Developer", "8-666-222-44-33"));

            _departments[1].Employees.Add(new Employee("Anna", "Solovieva", "29", "Human Resources", "Head", "8-666-111-99-88"));
            _departments[1].Employees.Add(new Employee("Maria", "Krunina", "20", "Human Resources", "Agent", "8-555-777-44-99"));
            _departments[1].Employees.Add(new Employee("Olesya", "Panina", "21", "Human Resources", "Agent", "8-333-222-88-44"));

            _departments[2].Employees.Add(new Employee("Olga", "Troina", "35", "Financial", "Head", "8-555-777-44-99"));
            _departments[2].Employees.Add(new Employee("Ekaterina", "Sorokina", "27", "Financial", "Accountant", "8-666-777-22-44"));

            UpdateComboBox();
        }

        /// <summary>
        /// Обновление списка департаментов
        /// </summary>
        public void UpdateComboBox()
        {
            _dataBase.ComboBox.Items.Clear();
            if (_departments.Count != 0)
                foreach (var department in _departments)
                    _dataBase.ComboBox.Items.Add(department.Name);
        }

        /// <summary>
        /// Обновление списка сотрудников
        /// </summary>
        public void UpdateListView()
        {
            _dataBase.ListView.Items.Clear();
            if (_currentDepartment != null)
                foreach (var employee in _currentDepartment.Employees)
                    _dataBase.ListView.Items.Add(employee.FirstName + " " + employee.SecondName);
        }

        /// <summary>
        /// Выбор департамента
        /// </summary>
        public void DepartmentSelected()
        {
            _currentDepartment = _departments.Find(department => department.Name == _dataBase.ComboBox.SelectedItem);
            UpdateListView();
        }

        /// <summary>
        /// Добавление нового департамента
        /// </summary>
        public void AddDepartment()
        {
            _departments.Add(new Department(_dataBase.NewDepartment));
            _dataBase.NewDepartment = "";
            UpdateComboBox();
            MessageBox.Show("Департамент добавлен", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Работник выбран
        /// </summary>
        public void EmployeeSelect()
        {
            if (_dataBase.ListView.SelectedIndex != -1)
            {
                _currentEmployee = _currentDepartment.Employees[_dataBase.ListView.SelectedIndex];
                _dataBase.FirstName = _currentEmployee.FirstName;
                _dataBase.SecondName = _currentEmployee.SecondName;
                _dataBase.Age = _currentEmployee.Age;
                _dataBase.Department = _currentEmployee.Department;
                _dataBase.Post = _currentEmployee.Post;
                _dataBase.Phone = _currentEmployee.Phone;
            }
        }

        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        public void AddEmployee()
        {
            var department = _departments.Find(x => x.Name == _dataBase.Department);
            if (department == null)
            {
                var temp = MessageBox.Show("Указанного департамента не существует!\nХотите создать?",
                    "Департамент не найден", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (temp == MessageBoxResult.Yes)
                {
                    department = new Department(_dataBase.Department);
                    _departments.Add(department);
                    UpdateComboBox();
                }
                else
                {
                    return;
                }
            }
            department.Employees.Add(new Employee(_dataBase.FirstName, _dataBase.SecondName, _dataBase.Age,
                                                  _dataBase.Department, _dataBase.Post, _dataBase.Phone));
            MessageBox.Show("Сотрудник добавлен!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            UpdateListView();
        }

        /// <summary>
        /// Изменение данных о сотрудника
        /// </summary>
        public void ChangeEmployee()
        {
            if (_currentEmployee != null)
            {
                _currentEmployee.FirstName = _dataBase.FirstName;
                _currentEmployee.SecondName = _dataBase.SecondName;
                _currentEmployee.Age = _dataBase.Age;
                _currentEmployee.Department = _dataBase.Department;
                _currentEmployee.Post = _dataBase.Post;
                _currentEmployee.Phone = _dataBase.Phone;
                MessageBox.Show("Данные о сотруднике изменены!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        public void DeleteEmployee()
        {
            if (_currentEmployee != null)
            {
                _currentDepartment.Employees.Remove(_currentEmployee);
                _currentEmployee = null;
                UpdateListView();
                MessageBox.Show("Сотрудник удален", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
