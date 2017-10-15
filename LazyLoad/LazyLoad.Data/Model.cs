namespace LazyLoad.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model")
        {
        }

        public virtual DbSet<Caso> Caso { get; set; }
        public virtual DbSet<Ejecucion> Ejecucion { get; set; }
        public virtual DbSet<Ejecutor> Ejecutor { get; set; }
        public virtual DbSet<Elemento> Elemento { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caso>()
                .HasMany(e => e.Elemento)
                .WithRequired(e => e.Caso)
                .HasForeignKey(e => e.IdCaso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ejecucion>()
                .HasMany(e => e.Caso)
                .WithRequired(e => e.Ejecucion)
                .HasForeignKey(e => e.IdEjecucion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ejecutor>()
                .Property(e => e.Cedula)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Ejecutor>()
                .HasMany(e => e.Ejecucion)
                .WithRequired(e => e.Ejecutor)
                .HasForeignKey(e => e.IdEjecutor)
                .WillCascadeOnDelete(false);
        }
    }
}
