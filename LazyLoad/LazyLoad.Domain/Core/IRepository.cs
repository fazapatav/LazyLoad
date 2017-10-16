

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LazyLoad.Domain.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        void Add(TEntity item);

        /// <summary>
        /// Add item collection into repository
        /// </summary>
        /// <param name="item">Items to add to repository</param>
        void AddRange(IList<TEntity> items);

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Delete(TEntity item);

        /// <summary>
        /// Delete item by of type {T} that matching a
        /// Specification <paramref name="where"/>
        /// </summary>
        /// <param name="where">Item or items to delete</param>
        void DeleteWhere(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Sets modified entity into the repository.
        /// When calling Commit() method in UnitOfWork
        /// these changes will be saved into the storage
        /// <remarks>
        /// Internally this method always calls Repository.Attach() and Context.SetChanges()
        /// </remarks>
        /// </summary>
        /// <param name="item">Item with changes</param>
        void Modify(TEntity item);

        /// <summary>
        /// Sets modified entity into the repository.
        /// When calling Commit() method in UnitOfWork
        /// these changes will be saved into the storage
        /// <remarks>
        /// Internally this method always calls Repository.Attach() and Context.SetChanges()
        /// </remarks>
        /// </summary>
        /// <param name="items">Items with changes</param>
        void ModifyRange(IList<TEntity> items);

        /// <summary>
        /// Get  elements of type {T} in repository
        /// </summary>
        /// <param name="filter">Filter that each element do match</param>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> where);

        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);

        #region Queryable

        IQueryable<TEntity> GetAllQueryable();

        IQueryable<TEntity> GetFilteredElementsQueryable(Expression<Func<TEntity, bool>> filter, params string[] include);

        #endregion Queryable
    
    }
}
