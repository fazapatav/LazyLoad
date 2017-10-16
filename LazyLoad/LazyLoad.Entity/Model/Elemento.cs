using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Entity.Model
{
    [Table("Elemento")]
    public partial class Elemento
    {
        public int Id { get; set; }

        public int IdCaso { get; set; }

        public int Valor { get; set; }

        public virtual Caso Caso { get; set; }
    }
}
