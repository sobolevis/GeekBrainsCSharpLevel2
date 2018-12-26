using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Lesson6.Model;
using Lesson6.View;

namespace Lesson6.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        Department _selectedDepartment;
        Employee _selectedEmployee;

        public MainWindowViewModel()
        {
            Init();
        }

        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        // Избыточная коллекция (выбор сотрудников одного департамента)
        public ObservableCollection<Employee> Staff { get; set; }

        /// <summary>
        /// Выбранный департамент
        /// </summary>
        public Department SelectedDepartment
        {
            get => _selectedDepartment;
            set
            {
                _selectedDepartment = value;
                OnPropertyChanged(nameof(SelectedDepartment));
                
                // Метод избыточной коллекции
                RefreshStaff();
            }
        }

        /// <summary>
        /// Выбранный сотрудник
        /// </summary>
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Изменение свойства
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddDepartmentCommand { get; set; }
        public ICommand DelDepartmentCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand DelEmployeeCommand { get; set; }

        /// <summary>
        /// Добавить департамент
        /// </summary>
        /// <param name="obj"></param>
        private void AddDepartment(object obj)
        {
           new AddDepartmentWindow(Departments).ShowDialog();
        }
        
        /// <summary>
        /// Удалить департамент
        /// </summary>
        /// <param name="obj"></param>
        private void DelDepartment(object obj)
        {
            Departments.Remove(_selectedDepartment);
        }

        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="obj"></param>
        private void AddEmployee(object obj)
        {
            new AddEmployeeWindow(Departments, Employees).ShowDialog();
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="obj"></param>
        private void DelEmployee(object obj)
        {
            Employees.Remove(_selectedEmployee);

            // Метод избыточной коллекции
            RefreshStaff();
        }

        // Метод избыточной коллекции
        /// <summary>
        /// Выборка сотрудников департамента
        /// </summary>
        private void RefreshStaff()
        {
            Staff.Clear();
            foreach (var employee in Employees)
            {
                if (employee.Department == _selectedDepartment?.Name) Staff.Add(employee);
            }
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        private void Init()
        {
            Departments = new ObservableCollection<Department>();
            Employees = new ObservableCollection<Employee>();
            Staff = new ObservableCollection<Employee>();

            AddDepartmentCommand = new DelegateCommand(AddDepartment);
            DelDepartmentCommand = new DelegateCommand(DelDepartment);
            AddEmployeeCommand = new DelegateCommand(AddEmployee);
            DelEmployeeCommand = new DelegateCommand(DelEmployee);

            GetDataBase();
        }

        /// <summary>
        /// Заполнение базы данных
        /// </summary>
        private void GetDataBase()
        {
            Random rnd = new Random();
            int countDepartments = 10;
            int countEmployees = 50;

            for (int i = 0; i < countDepartments; i++)
            {
                Departments.Add(new Department($"Департамент {i + 1}", rnd.Next(countDepartments).ToString()));
            }

            for (int i = 0; i < countEmployees; i++)
            {
                Employees.Add(new Employee($"Имя {i + 1 }",
                    $"Фамилия {i + 1}",
                    Departments[rnd.Next(countDepartments)].Name,
                    $"Должность {i + 1}",
                    $"Телефон {i + 1}"));
            }
        }

    }
}
