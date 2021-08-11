using Challenge.Nubimetrics.Application.Handlers.Busqueda;
using Challenge.Nubimetrics.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Api.Controllers
{
    [Route("api/[controller]")]
    public class BusquedaController : ControllerBase
    {
        private readonly IMediator mediator;

        public BusquedaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{termino}")]
        public async Task<ActionResult<IEnumerable<BusquedaModel>>> Get([FromRoute]string termino)
        {
            var result = await mediator.Send(new BusquedaGetByTerminoRequest(termino));

            return Ok(result);
        }
    }
}
