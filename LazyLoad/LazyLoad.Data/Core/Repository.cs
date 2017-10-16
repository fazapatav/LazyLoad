

using LazyLoad.Data.Core.Interfaces;
using LazyLoad.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LazyLoad.Data.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbSet<TEntity> _dbSet;
        private IQueryableUnitOfWork _unitOfWork;

        #region Constructor

        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("unitOfWork");
            _dbSet = _unitOfWork.CreateSet<TEntity>();
        }

        #endregion Constructor

        #region IRepository<TEntity> Members

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork as IUnitOfWork;
            }
        }

        public virtual void Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _dbSet.Add(item);
        }

        public void AddRange(IList<TEntity> items)
        {
            if (!items.Any())
            {
                throw new ArgumentNullException("items");
            }

            ((DbSet<TEntity>)_dbSet).AddRange(items);
        }

        public void DeleteWhere(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> objects = _dbSet.Where(where).AsEnumerable();

            foreach (TEntity obj in objects)
            {
                _dbSet.Remove(obj);
            }
        }

        public void Delete(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _unitOfWork.Attach(item);

            _dbSet.Remove(item);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> GetFilteredElements(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            return _dbSet.Where(filter).ToList();
        }

        public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }

        public virtual void Modify(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _unitOfWork.SetModified<TEntity>(item);
        }

        public void ModifyRange(IList<TEntity> items)
        {
            if (!items.Any())
            {
                throw new ArgumentNullException("items");
            }

            foreach (TEntity item in items)
            {
                _unitOfWork.SetModified<TEntity>(item);
            }
        }

        #region Queryable

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> GetFilteredElementsQueryable(Expression<Func<TEntity, bool>> filter, params string[] include)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            IQueryable<TEntity> query = _dbSet.Where(filter);

            foreach (string item in include)
            {
                query = query.Include(item);
            }

            return query;
        }

        #endregion Queryable

        #endregion IRepository<TEntity> Members

    }
}
