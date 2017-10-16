

using LazyLoad.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace LazyLoad.Data.UnitOfWork.EntityConfigurations
{
    internal class EjecutorConfiguration: EntityTypeConfiguration<Ejecutor>
    {
        public EjecutorConfiguration()
        {
            ToTable("Ejecutor");

            HasKey(t => t.Id);

            Property(item => item.Cedula)
               .HasColumnType("decimal")
               .HasPrecision(18,0)
               .IsRequired();

            HasMany(c => c.Ejecucion)
                .WithRequired(cp => cp.Ejecutor)
                .HasForeignKey(cp => cp.IdEjecutor);
        }
    }
}
