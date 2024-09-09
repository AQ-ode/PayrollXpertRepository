using Bulky.DataAccess.Repository;
using PayrollXpert.API.Api_Models.Employees;
using PayrollXpert.DataAccess.Data;

namespace PayrollXpert.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
        }


        public void update(Employee obj)
        {
            _db.Update(obj);
        }


    }

}
