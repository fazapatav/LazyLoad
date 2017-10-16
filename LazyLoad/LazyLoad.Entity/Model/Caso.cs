using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Entity.Model
{
    [Table("Caso")]
    public partial class Caso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Caso()
        {
            Elemento = new HashSet<Elemento>();
        }

        public int Id { get; set; }

        public int IdEjecucion { get; set; }

        public int Viajes { get; set; }

        public virtual Ejecucion Ejecucion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento> Elemento { get; set; }
    }
}
