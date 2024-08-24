using HotelReservationApi.Data;
using HotelReservationApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            //entry2.State
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
            //_context.Set<T>().Remove(entity);
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
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate,string model)
        {
            IQueryable<T> query = _context.Set<T>().Include(model).Where( predicate).AsNoTracking();
            var result = (IEnumerable<T>)query;//.ToList();
            return result;
        }
        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate,params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            // Apply predicate if provided
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // Return the result as a list
            var result =  await query.ToListAsync();
            return result;
        }
        
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().Where(x => !x.Deleted).AsNoTracking();
            //return _context.Set<T>().Where(x => !x.Deleted).AsNoTrackingWithIdentityResolution();
        }
        
        public T GetByID(int id)
        {
            //return _context.Find<T>(id);
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
        public async Task SaveChange()
        {
           await _context.SaveChangesAsync();
        }

    }
}
