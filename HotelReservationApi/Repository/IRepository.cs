using System.Linq.Expressions;

namespace HotelReservationApi.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        Task AddRange(List<T> list);
        T GetByID(int id);
        T GetWithTrackinByID(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        T First(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
