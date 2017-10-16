using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Entity.Model
{
    [Table("Ejecucion")]
    public partial class Ejecucion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ejecucion()
        {
            Caso = new HashSet<Caso>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public int IdEjecutor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caso> Caso { get; set; }

        public virtual Ejecutor Ejecutor { get; set; }
    }
}
