
using LazyLoad.Domain.Core;
using System.Data.Entity;

namespace LazyLoad.Data.Core.Interfaces
{
    public interface IQueryableUnitOfWork: IUnitOfWork
    {
        IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class;

        void Attach<TEntity>(TEntity item) where TEntity : class;

        void SetModified<TEntity>(TEntity item) where TEntity : class;

        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;

        TEntity Reload<TEntity>(TEntity item) where TEntity : class;

        void Reload<TEntity>() where TEntity : class;

        void DetachEntities<TEntity>() where TEntity : class;
    }
}
