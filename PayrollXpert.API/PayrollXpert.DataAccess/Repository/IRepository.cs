using System.Linq.Expressions;

namespace PayrollXpert.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        void Add(T entity);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

    }
}
