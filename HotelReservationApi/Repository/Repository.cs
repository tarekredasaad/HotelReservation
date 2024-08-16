using HotelReservationApi.Data;
using HotelReservationApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace HotelReservationApi.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        Context _context;
        public Repository(Context context)
        {
            _context = context;
        }
        public void astracking()
        {
           _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }
        public async Task<T> Add(T entity)
        {
            
             _context.Set<T>().Add(entity);
            var entry = _context.ChangeTracker.Entries<User>();
            var entry2 = _context.Entry(entity);
            //entry2.State
            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
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


    }
}
