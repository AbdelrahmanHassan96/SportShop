using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.DataAccess.Repositories
{
    public interface IBaseRepository <T>where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? criteria = null, string? include = null);
        T GetT(Expression<Func<T, bool>>? criteria = null, string? include = null);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
