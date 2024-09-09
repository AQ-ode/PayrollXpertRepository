using PayrollXpert.API.Api_Models.Employees;
using PayrollXpert.DataAccess.Repository;

namespace Bulky.DataAccess.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void update(Employee obj);
    }
}
