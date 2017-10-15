using LazyLoad.Aplication.Dto.Ejecucion;
using LazyLoad.Aplication.Services.Casos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LazyLoad.Api.Controllers
{
    public class EjecucionController : ApiController
    {
        #region Member
        private readonly ICasosServices _casosServices;
        #endregion Member
        #region Constructor
        public EjecucionController(ICasosServices casosServices)
        {
            this._casosServices = casosServices;
        }
        #endregion
        #region Methods
        // POST:
        [HttpPost]
        //FromBody especifica que los parametros provienen a traves del pos (json)
        public HttpResponseMessage CargarArchivo([FromBody]EjecucionDto ejecucion)
        {
            List<string> result = _casosServices.ObtenerCasos(ejecucion);
            return Request.CreateResponse(HttpStatusCode.OK, $"I want more money {ejecucion.Cedula}");
        }
        #endregion

    }
}