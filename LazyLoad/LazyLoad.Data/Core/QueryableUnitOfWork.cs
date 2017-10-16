

using LazyLoad.Data.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace LazyLoad.Data.Core
{
    public class QueryableUnitOfWork : DbContext, IQueryableUnitOfWork
    {
        public QueryableUnitOfWork()
            : base()
        {
            /*
             * This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
             * As it is installed in the GAC, Copy Local does not work. It is required for probing.
             * Fixed "Provider not loaded" error
            */
            #pragma warning disable S1481 // Unused local variables should be removed
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            #pragma warning restore S1481 // Unused local variables should be removed
        }

        public QueryableUnitOfWork(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        #region IQueryableUnitOfWork Members

        public virtual IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item) where TEntity : class
        {
            base.Entry<TEntity>(item).State = EntityState.Unchanged;
        }

        public virtual void SetModified<TEntity>(TEntity item) where TEntity : class
        {
            try
            {
                var entityState = base.Entry<TEntity>(item).State;
                if (entityState == EntityState.Detached)
                {
                    var id = item.GetType().GetProperty("Id").GetValue(item);
                    ApplyCurrentValues<TEntity>(base.Set<TEntity>().Find(id), item);
                    base.Entry<TEntity>(base.Set<TEntity>().Find(id));
                }
                else
                {
                    base.Entry<TEntity>(item).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Excepción no controlada en el método SetModified de QueryableUnitOfWork", ex);
            }
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public TEntity Reload<TEntity>(TEntity item) where TEntity : class
        {
            if (item != null)
            {
                var context = ((IObjectContextAdapter)this).ObjectContext;

                context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, item);

                this.Entry(item).Reload();

                var id = item.GetType().GetProperty("Id").GetValue(item);
                return base.Set<TEntity>().Find(id);
            }

            return item;
        }

        public void DetachEntities<TEntity>()
            where TEntity : class
        {
            base.Set<TEntity>().Local.ToList().ForEach(p => base.Entry(p).State = EntityState.Detached);
        }

        #endregion IQueryableUnitOfWork Members

        #region IUnitOfWork Members

        public int Commit()
        {
            return base.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return base.SaveChangesAsync();
        }

        public void Reload<TEntity>() where TEntity : class
        {
            var context = ((IObjectContextAdapter)this).ObjectContext;

            context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, context.ObjectStateManager.GetObjectStateEntries(EntityState.Unchanged | EntityState.Modified));
        }

        #endregion IUnitOfWork Members
    }
}
