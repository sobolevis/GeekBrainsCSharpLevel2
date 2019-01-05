using CompanyDatabaseAccess;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIService.Controllers
{
    public class DepartmentsController : ApiController
    {
        public IEnumerable<Department> Get()
        {
            using (CompanyDatabaseEntities entities = new CompanyDatabaseEntities())
            {
                return entities.Departments.ToList();
            }
        }

        public Department Get(int id)
        {
            using (CompanyDatabaseEntities entities = new CompanyDatabaseEntities())
            {
                return entities.Departments.FirstOrDefault(d => d.Id == id);
            }
        }
    }
}
