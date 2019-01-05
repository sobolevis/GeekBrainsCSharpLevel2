using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CompanyDatabaseAccess;

namespace WebAPIService.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (CompanyDatabaseEntities entities = new CompanyDatabaseEntities())
            {
                return entities.Employees.ToList();
            }
        }

        public Employee Get(int id)
        {
            using (CompanyDatabaseEntities entities = new CompanyDatabaseEntities())
            {
                return entities.Employees.FirstOrDefault(e => e.Id == id);
            }
        }

    }
}













/*
        private List<Employee> _employees;
        private List<Department> _departments;

        public EmployeesController()
        {
            _departments = new List<Department>();
            _employees = new List<Employee>();
           GetDataBase();
        }

        /// <summary>
        /// Получить список департаментов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> GetDepartments()
        {
            return _departments;
        }
        /*
        /// <summary>
        /// Получить список сотрудников принадлежащих департаменту
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAllEmployees(Department department)
        {
            return _employees.FindAll(x => x.Department == department.Name);
        }
        


        /// <summary>
        /// Создание базы данных
        /// </summary>
        private void GetDataBase()
        {
            Random rnd = new Random();
            int countDepartments = 10;
            int countEmployees = 50;

            for (int i = 0; i < countDepartments; i++)
            {
                _departments.Add(new Department($"Департамент {i + 1}", rnd.Next(countDepartments).ToString()));
            }

            for (int i = 0; i < countEmployees; i++)
            {
                _employees.Add(new Employee($"Имя {i + 1 }",
                    $"Фамилия {i + 1}",
                    _departments[rnd.Next(countDepartments)].Name,
                    $"Должность {i + 1}",
                    $"Телефон {i + 1}"));
            }
        }*/
