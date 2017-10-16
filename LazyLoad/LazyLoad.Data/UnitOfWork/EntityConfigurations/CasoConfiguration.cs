

using LazyLoad.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace LazyLoad.Data.UnitOfWork.EntityConfigurations
{
    internal class CasoConfiguration : EntityTypeConfiguration<Caso>
    {
        public CasoConfiguration()
        {
            ToTable("Caso");
            HasKey(t => t.Id);
            Property(item => item.Viajes)
                .HasColumnType("int")
                .IsRequired();

            HasRequired(item => item.Ejecucion)
                .WithMany(item => item.Caso)
                .HasForeignKey(s => s.IdEjecucion);

            HasMany(c => c.Elemento)
                .WithRequired(cp => cp.Caso)
                .HasForeignKey(cp => cp.IdCaso);
        }
        
    }
}
