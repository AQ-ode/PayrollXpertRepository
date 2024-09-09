using Bulky.DataAccess.Repository;
using PayrollXpert.DataAccess.Data;

namespace PayrollXpert.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public IEmployeeRepository Employee { get; private set; }


        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {

            _db = db;
            Employee = new EmployeeRepository(_db);

        }
        public void save()
        {
            _db.SaveChanges();
        }
    }
}
