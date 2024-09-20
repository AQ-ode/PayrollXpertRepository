using PayrollXpert.Models.Employees;

namespace PayrollXpert.DataAccess.Repository
{
    public interface IEmployeeShiftInformationRepository : IRepository<EmployeeShiftInformation>
    {
        void update(EmployeeShiftInformation obj);
    }
}
