using PayrollXpert.DataAccess.Data;
using PayrollXpert.Models.Employees;

namespace PayrollXpert.DataAccess.Repository
{
    public class EmployeeQualificationRepository : Repository<EmployeeQualification>, IEmployeeQualificationRepository
    {
        private ApplicationDbContext _db;
        public EmployeeQualificationRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
        }


        public void update(EmployeeQualification obj)
        {
            _db.Update(obj);
        }
    }
}
