using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Input;
using CompanyDatabaseAccess;

namespace WebAPIClient.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        static HttpClient client;

        List<Department> _departments;
        List<Employee> _employees;
        Department _selectedDepartment;
        Employee _selectedEmployee;

        public MainWindowViewModel()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50681/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            UpdateDepartmentsCommand = new DelegateCommand(UdpateDepartments);
        }

        /// <summary>
        /// Список департаментов
        /// </summary>
        public List<Department> Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                _departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }

        /// <summary>
        /// Список сотрудников департамента
        /// </summary>
        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        /// <summary>
        /// Выбранный департамент
        /// </summary>
        public Department SelectedDepartment
        {
            get => _selectedDepartment;
            set
            {
                _selectedDepartment = value;
                UpdateEmployees();
                OnPropertyChanged(nameof(SelectedDepartment));
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

        /// <summary>
        /// Команда обновления списка департаментов
        /// </summary>
        public ICommand UpdateDepartmentsCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Изменение свойства
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }    

        /// <summary>
        /// Обновление списка департаментов
        /// </summary>
        /// <param name="obj"></param>
        async void UdpateDepartments(object obj)
        {
            Departments = await GetAllDepartments();
        }

        /// <summary>
        /// Обновление списка сотрудников департамента
        /// </summary>
        async void UpdateEmployees()
        {
            List<Employee> temp = await GetAllEmployees();
            Employees = temp.Where(x => x.Department == SelectedDepartment.Name).ToList();
        }

        /// <summary>
        /// Получение списка всех департаментов из базы данных
        /// </summary>
        /// <returns></returns>
        async Task<List<Department>> GetAllDepartments()
        {
            string str = client.BaseAddress + "api/Departments";
            List<Department> departments = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(str);
                if (response.IsSuccessStatusCode)
                {
                    departments = await response.Content.ReadAsAsync<List<Department>>();
                }
            }
            catch { }
            return departments;
        }

        /// <summary>
        /// Получение списка всех сотрудников из базы данных
        /// </summary>
        /// <returns></returns>
        async Task<List<Employee>> GetAllEmployees()
        {
            string path = client.BaseAddress + "api/Employees";
            List<Employee> employees = null;
            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync(path);
                if (responseMessage.IsSuccessStatusCode)
                {
                    employees = await responseMessage.Content.ReadAsAsync<List<Employee>>();
                }
            }
            catch { }
            return employees;
        }
    }
}
