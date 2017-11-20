using Microsoft.EntityFrameworkCore;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mugi.Core.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private MugiStoreDbContext dbContext;
        private DbSet<TEntity> dbSet;

        public Repository(MugiStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        #region Implement

        public void Add(TEntity entity)
        {
          dbSet.Add(entity);
        }

        public TEntity AddAndGetId(TEntity entity)
        {
            return dbSet.Add(entity).Entity;
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            //entityToDelete.DeletedDate = DateTime.Now;

            if (dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
                return orderBy(query);
            else
                return query.ToList();
        }

        public IEnumerable<TEntity> GetDistinct(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
                return orderBy(query.Distinct());
            else
                return query.Distinct().ToList();
        }

        public IEnumerable<TEntity> GetDistinctNoTracking(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
                return orderBy(query.Distinct().AsNoTracking());
            else
                return query.Distinct().AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetWithNoTracking(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
                return orderBy(query.AsNoTracking());
            else
                return query.AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            IQueryable<TEntity> query = dbSet;
            return dbSet.Find(id);
        }

        public void Update(TEntity entityToUpdate)
        {
            //entityToUpdate.ModifiedDate = DateTime.Now;

            dbSet.Attach(entityToUpdate);
            dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void UpdateOneField(TEntity entityToUpdate, string propertyName)
        {
            //entityToUpdate.ModifiedDate = DateTime.Now;

            dbSet.Attach(entityToUpdate);
            dbContext.Entry(entityToUpdate).Property(propertyName).IsModified = true;
        }



        public IQueryable<TEntity> GetIQueryable(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                return orderBy(query);
            else
                return query;
        }
        #endregion
    }
}
