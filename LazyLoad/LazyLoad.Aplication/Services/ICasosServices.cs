using LazyLoad.Aplication.Dto.Ejecucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Aplication.Services
{
    public interface ICasosServices
    {
        List<string> ObtenerCasos(EjecucionDto ejecucion);
    }
}
