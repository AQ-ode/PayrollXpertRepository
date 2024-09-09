using PayrollXpert.DataAccess.Data;
using PayrollXpert.Models;

namespace PayrollXpert.DataAccess.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
        }


        public void update(Department obj)
        {
            _db.Update(obj);
        }
    }
}
