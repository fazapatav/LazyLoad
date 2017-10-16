using LazyLoad.Entity.Model;
using System.Data.Entity.ModelConfiguration;


namespace LazyLoad.Data.UnitOfWork.EntityConfigurations
{
    internal class EjecucionConfiguration: EntityTypeConfiguration<Ejecucion>
    {
        public EjecucionConfiguration()
        {
            ToTable("Ejecucion");
            HasKey(t => t.Id);

            Property(item => item.Fecha)
              .HasColumnType("DateTime")
              .IsRequired();

            HasRequired(item => item.Ejecutor)
              .WithMany(item => item.Ejecucion)
              .HasForeignKey(s => s.IdEjecutor);

            HasMany(c => c.Caso)
                .WithRequired(cp => cp.Ejecucion)
                .HasForeignKey(cp => cp.IdEjecucion);
        }
    }
}
