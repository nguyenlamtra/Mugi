using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mugi.Core.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // Get entities with order by or not
        // Include GetAll() and GetMany() by criteria expression
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IEnumerable<TEntity> GetWithTakeAndSkip(int skip, int take,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IEnumerable<TEntity> GetWithNoTracking(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");

        IEnumerable<TEntity> GetDistinct(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IEnumerable<TEntity> GetDistinctNoTracking(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IQueryable<TEntity> GetIQueryable(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        // Get an entity by int id
        TEntity GetById(int id);

        // Marks an entity as new
        void Add(TEntity entity);

        // Marks an entity as modified
        void Update(TEntity entity);

        // Marks an entity to be deleted
        void Delete(object id);
        void Delete(TEntity entity);

        void UpdateOneField(TEntity entityToUpdate, string propertyName);
    }
}
