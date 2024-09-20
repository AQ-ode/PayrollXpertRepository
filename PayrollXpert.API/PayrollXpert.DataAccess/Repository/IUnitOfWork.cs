using Bulky.DataAccess.Repository;

namespace PayrollXpert.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        IEmployeeQualificationRepository Qualification { get; }
        IEmployeeShiftInformationRepository ShiftInformation { get; }

        void save();
    }
}
