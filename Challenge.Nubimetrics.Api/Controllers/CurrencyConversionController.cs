using Challenge.Nubimetrics.Application.Handlers.CurrencyConversion;
using Challenge.Nubimetrics.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Api.Controllers
{
    [Route("api/[controller]")]

    public class CurrencyConversionController : ControllerBase
    {
        private readonly IMediator mediator;
        public CurrencyConversionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyConversionModel>>> Get()
        {
            var result = await mediator.Send(new CurrencyConversionGetAllRequest());

            return Ok(result);
        }
    }
}
