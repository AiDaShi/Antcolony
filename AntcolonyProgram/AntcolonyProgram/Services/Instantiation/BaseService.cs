using AntcolonyProgram.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AntcolonyProgram.Services.Instantiation
{
    public abstract class BaseService<T> where T : class, new()
    {
        public BaseService(AntcolonyContext dbContentFactory) {
            db = dbContentFactory;
        }
        //DataModelContainer db = new DataModelContainer();
        public DbContext db;

        public async Task<T> GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAlllist()
        {
            return await db.Set<T>().ToListAsync();
        }
        public  IQueryable<T> GetEntity(Expression<Func<T, bool>> wherelambda)
        {
            return db.Set<T>().Where(wherelambda).AsQueryable();
        }
        public IQueryable<T> GetPageEntity<S>(int page, int pageSize, out int total, Expression<Func<T, bool>> wherelambda,
            Expression<Func<T, S>> orderziduan, bool isAsc)
        {
            total = db.Set<T>().Where(wherelambda).Count();
            if (isAsc)
            {
                var temp = db.Set<T>().Where(wherelambda)
                    .OrderBy<T, S>(orderziduan)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .AsQueryable();
                return temp;
            }
            else
            {
                var temp = db.Set<T>().Where(wherelambda)
                    .OrderByDescending<T, S>(orderziduan)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .AsQueryable();
                return temp;

            }
        }
        public async Task<T> Add(T entity)
        {
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return await db.SaveChangesAsync() > 0;
            //return true;
        }
        public async Task<bool> Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return await db.SaveChangesAsync() > 0;
            //return true;
        }
    }
}
