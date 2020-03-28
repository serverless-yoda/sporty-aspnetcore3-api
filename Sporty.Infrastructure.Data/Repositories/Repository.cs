using Microsoft.EntityFrameworkCore;
using Sporty.Domain.IRepository;
using Sporty.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sporty.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SportyContext db;
        internal DbSet<T> dbSet;

        public Repository(SportyContext db)
        {
            this.db = db;
            this.dbSet = this.db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeFields = null)
        {
            IQueryable<T> fromdb = dbSet;

            if(filter != null )
            {
                fromdb = fromdb.Where(filter);
            }

            
            if(string.IsNullOrEmpty(includeFields))
            {
                foreach(string field in includeFields.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    fromdb = fromdb.Include(field);
                }
            }

            if (orderBy != null)
            {
                return orderBy(fromdb).ToList();
            }

            return fromdb.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeFields = null)
        {
            IQueryable<T> fromdb = dbSet;

            if (filter != null)
            {
                fromdb = fromdb.Where(filter);
            }


            if (string.IsNullOrEmpty(includeFields))
            {
                foreach (string field in includeFields.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    fromdb = fromdb.Include(field);
                }
            }

            

            return fromdb.FirstOrDefault();
        }

        public void Remove(int id)
        {
            var fromdb = dbSet.Find(id);
            Remove(fromdb);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRanges(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
