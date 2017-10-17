

using LazyLoad.Domain.DomainContracts;
using LazyLoad.Entity.Model;
using System.Collections.Generic;
using System.Linq;

namespace LazyLoad.Domain.DomainServices
{
    public class EjecucionDomain: IEjecucionDomain
    {
        #region Members
        private ICasoDomain _casoDomain;
        #endregion Members
        public EjecucionDomain(ICasoDomain casoDomain)
        {
            _casoDomain = casoDomain;
        }
        public void ObtenerCasos(List<int> carga)
        {
            int cantidadDeCasos = carga.First();
            Ejecucion ejecucion = new Ejecucion();
            int cantidadElementos = 0;
            int indiceCaso = 0;
            for (int i=0; i< cantidadDeCasos; i++)
            {
                indiceCaso = i == 0 ? 1 : indiceCaso + cantidadElementos+1;
                Caso caso = new Caso();
                caso.IdEjecucion = ejecucion.Id;
                cantidadElementos = carga[indiceCaso];
                for (int j = 0; j < cantidadElementos; j++)
                {
                    Elemento elemento = new Elemento();
                    elemento.IdCaso = caso.Id;
                    elemento.Valor = carga[indiceCaso+1+j];
                    caso.Elemento.Add(elemento);
                }
                caso.Viajes = _casoDomain.CalcularViajes(caso);
                ejecucion.Caso.Add(caso);
            }
            
        }
    }
}
