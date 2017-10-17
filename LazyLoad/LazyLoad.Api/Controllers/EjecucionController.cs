using LazyLoad.Aplication.Dto.Ejecucion;
using LazyLoad.Aplication.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LazyLoad.Api.Controllers
{
    public class EjecucionController : ApiController
    {
        #region Member
        private readonly IEjecucionServices _ejecucionServices;
        #endregion Member
        #region Constructor
        public EjecucionController(IEjecucionServices ejecucionServices)
        {
            this._ejecucionServices = ejecucionServices;
        }
        #endregion
        #region Methods
        // POST:
        [HttpPost]
        //FromBody especifica que los parametros provienen a traves del pos (json)
        public HttpResponseMessage CargarArchivo([FromBody]EjecucionDto ejecucion)
        {
            _ejecucionServices.ObtenerCasos(ejecucion);
            return Request.CreateResponse(HttpStatusCode.OK, $"I want more money {ejecucion.Cedula}");
        }
        #endregion

    }
}