using HotelReservationApi.Data;
using HotelReservationApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelReservationApi.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }
        
        public async Task<T> Add(T entity)
        {  
            await _context.Set<T>().AddAsync(entity);
            
            var entry2 = _context.Entry(entity);

            return entity;
        }

        public async Task AddRange(List<T> list)
        {
           await  _context.Set<T>().AddRangeAsync(list);
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            entity.Deleted = true;
            Update(entity);
        }

        public void Delete(int id)
        {
            T entity = _context.Find<T>(id);
            Delete(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x => !x.Deleted).AsNoTracking();
        }

        public T GetByID(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public T GetWithTrackinByID(int id)
        {
            return _context.Set<T>()
                    .Where(x => !x.Deleted && x.Id == id)
                    .AsTracking()
                    .FirstOrDefault();
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return Get(predicate).FirstOrDefault();
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
