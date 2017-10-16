using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Aplication.Dto.Ejecucion
{
   public class EjecucionDto
    {
        public long Cedula { get; set; }
        public List<int> Carga { get; set; }
    }
}
