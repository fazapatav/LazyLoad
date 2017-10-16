using LazyLoad.Aplication.Dto.Ejecucion;
using LazyLoad.Domain.RepositoriesContracts;
using LazyLoad.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Aplication.Services.Casos
{
    public class CasosServices:ICasosServices
    {

        #region Members
        private ICasoRepository _casoRepository;
        //borrar esto es una prueba
        private IEjecutorRepository _ejecutorRepository;
        #endregion Members
        #region constructor
        public CasosServices(ICasoRepository casoRepository, IEjecutorRepository ejecutorRepository)
        {
            _casoRepository = casoRepository;
            _ejecutorRepository = ejecutorRepository;
        }
        #endregion constructor

        public List<string> ObtenerCasos(EjecucionDto carga)
        {
            //se verica q la info llegue bien, se generan mensajes, se recibe resultado de domain y se retorna a api

            //esto es de prueba
            Ejecutor ejecutorTest = new Ejecutor();
            ejecutorTest.Cedula = 1035854453;
            _ejecutorRepository.Add(ejecutorTest);
            _ejecutorRepository.UnitOfWork.Commit();
            return new List<string>();
        }
    }
}
