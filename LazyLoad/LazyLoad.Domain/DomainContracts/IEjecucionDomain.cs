using LazyLoad.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Domain.DomainContracts
{
    public interface IEjecucionDomain
    {
        void ObtenerCasos(List<int> carga);
    }
}
