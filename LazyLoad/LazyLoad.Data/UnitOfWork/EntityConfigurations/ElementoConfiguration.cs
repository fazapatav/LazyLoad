

using LazyLoad.Entity.Model;
using System.Data.Entity.ModelConfiguration;

namespace LazyLoad.Data.UnitOfWork.EntityConfigurations
{
    internal class ElementoConfiguration : EntityTypeConfiguration<Elemento>
    {
        public ElementoConfiguration()
        {
            ToTable("Elemento");

            HasKey(t => t.Id);

            Property(item => item.Valor)
              .HasColumnType("int")
              .IsRequired();

            HasRequired(item => item.Caso)
             .WithMany(item => item.Elemento)
             .HasForeignKey(s => s.IdCaso);
        }
        
    }
}
