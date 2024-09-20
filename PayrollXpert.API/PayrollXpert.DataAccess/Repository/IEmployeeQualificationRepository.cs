using PayrollXpert.Models.Employees;

namespace PayrollXpert.DataAccess.Repository
{
    public interface IEmployeeQualificationRepository : IRepository<EmployeeQualification>
    {
        void update(EmployeeQualification obj);

    }
}
