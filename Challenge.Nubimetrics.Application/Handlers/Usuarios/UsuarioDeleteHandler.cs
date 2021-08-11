using AutoMapper;
using Challenge.Nubimetrics.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Handlers.Usuarios
{
    public class UsuarioDeleteRequest : IRequest<Unit>
    {
        public UsuarioDeleteRequest(int Id)
        {
            this.Id = Id;
        }
        public int Id { get;}
    }
    public class UsuarioDeleteHandler : IRequestHandler<UsuarioDeleteRequest, Unit>
    {
        private readonly ILogger<UsuarioDeleteHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public UsuarioDeleteHandler(ILogger<UsuarioDeleteHandler> logger, IUserDbService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UsuarioDeleteRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Elimino usuario. usuarioID: {{userID}}", request.Id);

            var userEntity = await service.GetByID(request.Id);

            await service.DeleteUser(userEntity);

            return Unit.Value;
        }
    }
}
