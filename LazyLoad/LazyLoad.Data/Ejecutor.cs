namespace LazyLoad.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ejecutor")]
    public partial class Ejecutor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ejecutor()
        {
            Ejecucion = new HashSet<Ejecucion>();
        }

        public int Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Cedula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ejecucion> Ejecucion { get; set; }
    }
}
