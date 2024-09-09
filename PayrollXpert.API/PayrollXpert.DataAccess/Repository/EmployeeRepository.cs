using Bulky.DataAccess.Repository;
using PayrollXpert.API.Api_Models.Employees;
using PayrollXpert.DataAccess.Data;

namespace PayrollXpert.DataAccess.Repository
{
    public class EmployeeRepository : Repository<EmployeeRepository>, IEmployeeRepository
    {
        private ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
        }

        public void Add(Employee entity)
        {
            _db.Add(entity);
        }

        public void update(Employee obj)
        {
            _db.Update(obj);
        }


    }

}
