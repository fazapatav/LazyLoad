using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Entity.Model
{
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
