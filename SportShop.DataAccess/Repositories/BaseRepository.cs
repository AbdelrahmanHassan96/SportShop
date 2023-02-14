using Microsoft.EntityFrameworkCore;
using SportShop.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DataAccess.Repositories
{
    public class BaseRepository <T>: IBaseRepository <T>  where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbset;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset =  _context.Set<T>();
        }

        public void Add(T item)
        {
            _dbset.Add(item);
        }

        public void Delete(T item)
        {
            _dbset.Remove(item);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? criteria = null, string? include = null)
        {
            IQueryable<T> query = _dbset;
            if(criteria != null)
            {
                query = query.Where(criteria);
            }
            if(include != null)
            {
                query = query.Include(include);
            }
            return query.ToList();
        }

        public T GetT(Expression<Func<T, bool>>? criteria = null, string? include = null)
        {
            IQueryable<T> query = _dbset;
            if (include != null)
                query = query.Include(include);
            return query.SingleOrDefault(criteria);
        }

        public void Update(T item)
        {
            _dbset.Update(item);
        }
    }
}
