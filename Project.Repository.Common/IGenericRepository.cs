using Project.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Project.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(
            List<string> includes = null
            );
        Task<IPagedList<T>> GetPaged(
            RequestParams requestParams,
            List<string> includes = null
            );
        Task<T> Get(
            Expression<Func<T, bool>> exception,
            List<string> includes = null
            );
        Task Insert(T entity);
        Task Delete(int id);
        void Update(T entity);
    }
}
