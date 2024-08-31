using System.Linq.Expressions;

namespace HotelReservationApi.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        Task AddRange(List<T> list);
        T GetByID(int id);
        T GetWithTrackinByID(int id);
        Task<T> AddAsync(T entity);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(int id);
       Task<T> First(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
