using LazyLoad.Aplication.Dto.Ejecucion;
using LazyLoad.Domain.DomainContracts;
using LazyLoad.Domain.RepositoriesContracts;
using LazyLoad.Entity.Model;
using System;

namespace LazyLoad.Aplication.Services
{
    public class EjecucionServices: IEjecucionServices
    {
        #region Members
        private IEjecucionDomain _ejecucionDomain;

        private IEjecutorRepository _ejecutorRepository;
        private IEjecucionRepository _ejecucionRepository;
        private ICasoRepository _casoRepository;
        private IElementoRepository _elementoRepository;
        #endregion Members

        #region Constructor
        public EjecucionServices(IEjecucionDomain ejecucionDomain,
            IEjecutorRepository ejecutorRepository,
            IEjecucionRepository ejecucionRepository,
            ICasoRepository casoRepository,
            IElementoRepository elementoRepository)
        {
            _ejecucionDomain = ejecucionDomain;
            _ejecutorRepository = ejecutorRepository;
            _ejecucionRepository = ejecucionRepository;
            _casoRepository = casoRepository;
            _elementoRepository = elementoRepository;
        }
        #endregion  

        public void ObtenerCasos(EjecucionDto ejecucionDto)
        {
            Ejecutor ejecutor = new Ejecutor();
            Caso y = new Caso();
            Elemento z = new Elemento();
            Ejecucion ejecucion = new Ejecucion();
            ejecutor.Cedula = 101;
            ejecutor.Ejecucion.Add(ejecucion);
            ejecucion.Fecha = DateTime.Now;
            ejecucion.IdEjecutor = ejecutor.Id;
            _ejecutorRepository.Add(ejecutor);
            _ejecucionRepository.Add(ejecucion);
            _ejecutorRepository.UnitOfWork.Commit();
            //_ejecucionDomain.ObtenerCasos(ejecucionDto.Carga);
        }
    }
}
