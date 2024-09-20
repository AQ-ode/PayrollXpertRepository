using PayrollXpert.DataAccess.Data;
using PayrollXpert.Models.Employees;

namespace PayrollXpert.DataAccess.Repository
{
    public class EmployeeShiftInformationRepository : Repository<EmployeeShiftInformation>, IEmployeeShiftInformationRepository
    {
        private ApplicationDbContext _db;
        public EmployeeShiftInformationRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
        }


        public void update(EmployeeShiftInformation obj)
        {
            _db.Update(obj);
        }

    }
}
