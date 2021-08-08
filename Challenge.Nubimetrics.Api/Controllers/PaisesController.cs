using Challenge.Nubimetrics.Application.Handlers.Paises;
using Challenge.Nubimetrics.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Api.Controllers
{
    [Route("api/[controller]")]
    public class PaisesController : ControllerBase
    {
        private readonly IMediator mediator;

        public PaisesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<PaisModel>> Get([FromRoute]string code)
        {
            var result = await mediator.Send(new PaisGetByCodeRequest(code));

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisModel>>> Get()
        {
            var result = await mediator.Send(new PaisGetAllRequest());

            return Ok(result);
        }
    }
}
