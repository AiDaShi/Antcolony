using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AntcolonyProgram.Services.Interface
{
    public interface IBaseService<T> where T : class, new()
    {

        #region all

        Task<T> GetById(int id);

        Task<List<T>> GetAlllist();
        IQueryable<T> GetEntity(Expression<Func<T, bool>> wherelambda);
        IQueryable<T> GetPageEntity<S>(int page, int pageSize, out int total, Expression<Func<T, bool>> wherelambda,
           Expression<Func<T, S>> orderziduan, bool isAsc);
        Task<T> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);

        #endregion
    }
}
