using LazyLoad.Data.Core;
using LazyLoad.Data.Core.Interfaces;
using LazyLoad.Data.UnitOfWork.EntityConfigurations;
using LazyLoad.Entity.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LazyLoad.Data.UnitOfWork
{
    public class LazyLoadUnitOfWork: QueryableUnitOfWork , ILazyLoadUnitOfWork
    {
        public LazyLoadUnitOfWork() : base("name=LazyLoadDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        #region IDbSet
        public IDbSet<Caso> Caso { get; set; }
        public IDbSet<Ejecucion> Ejecucion { get; set; }
        public IDbSet<Ejecutor> Ejecutor { get; set; }
        public IDbSet<Elemento> Elemento { get; set; }
        #endregion IDbSet

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Configurations
            modelBuilder.Configurations.Add(new CasoConfiguration());
            modelBuilder.Configurations.Add(new EjecucionConfiguration());
            modelBuilder.Configurations.Add(new EjecutorConfiguration());
            modelBuilder.Configurations.Add(new ElementoConfiguration());
            #endregion Configurations

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
