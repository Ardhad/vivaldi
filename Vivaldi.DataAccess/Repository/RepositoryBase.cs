using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Vivaldi.Api.DataAccess;
using Vivaldi.Api.Model;

namespace Vivaldi.DataAccess.Repository
{
   public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
      where TEntity : BaseEntity
   {
      private readonly DbSet<TEntity> _dbSet;
      private readonly VivaldiDbContext _dbContext;

      public RepositoryBase(VivaldiDbContext dbContext)
      {
         _dbContext = dbContext;
         _dbSet = _dbContext.Set<TEntity>();
      }

      public TEntity Get(int id)
      {
         return Find(entity=> entity.Id == id).FirstOrDefault();
      }

      public IQueryable<TEntity> Query()
      {
         return _dbSet;
      }

      public void Insert(TEntity entity)
      {
         _dbSet.Add(entity);
      }

      public void Insert(IEnumerable<TEntity> entities)
      {
         _dbSet.AddRange(entities);
      }

      public void Update(TEntity entity)
      {
         if (_dbContext.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);

         _dbContext.Entry(entity).State = EntityState.Modified;
      }

      public void Update(TEntity entity, List<Expression<Func<TEntity, object>>> propertiesToUpdate)
      {
         if (_dbContext.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);

         foreach (var propertyToModify in propertiesToUpdate)
         {
            _dbContext.Entry(entity).Property(propertyToModify).IsModified = true;
         }
      }

      public void Delete(int id)
      {
         var entity = Get(id);
         _dbSet.Remove(entity);
      }

      public void Delete(Expression<Func<TEntity, bool>> filter)
      {
         var entities = Find(filter);
         _dbSet.RemoveRange(entities);
      }

      public void Delete(TEntity entity)
      {
         if (entity == null)
            throw new ArgumentNullException("entity", "Given entity cannot be deleted or do not exist.");

         if (_dbContext.Entry(entity).State == EntityState.Detached)
         {
            _dbSet.Attach(entity);
         }

         _dbSet.Remove(entity);
      }

      public int Count(Expression<Func<TEntity, bool>> filter = null)
      {
         if (filter == null)
            return _dbSet.Count();

         return Find(filter).Count();
      }

      public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
      {
         return _dbSet.Where(filter);
      }

      public IEnumerable<TEntity> All => _dbSet.ToArray();
   }
}