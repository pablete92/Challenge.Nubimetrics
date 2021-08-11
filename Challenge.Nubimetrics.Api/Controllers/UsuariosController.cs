using Challenge.Nubimetrics.Application.Handlers.Usuarios;
using Challenge.Nubimetrics.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuariosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            var result = await mediator.Send(new UsuarioGetAllRequest());

            return Ok(result);
        }

        [HttpGet("ById/{Id}")]
        public async Task<ActionResult<UserModel>> Get([FromRoute]int Id)
        {
            var result = await mediator.Send(new UsuarioGetByIdRequest(Id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserModel userModel)
        {
            await mediator.Send(new UsuarioInsertRequest(userModel));

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserModel userModel)
        {
            await mediator.Send(new UsuarioPutRequest(userModel));

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int Id)
        {
            await mediator.Send(new UsuarioDeleteRequest(Id));

            return Ok();
        }
    }
}
