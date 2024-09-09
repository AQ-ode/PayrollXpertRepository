using PayrollXpert.Models;

namespace PayrollXpert.DataAccess.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        void update(Department obj);

    }
}
