namespace PayrollXpert.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

    }
}
