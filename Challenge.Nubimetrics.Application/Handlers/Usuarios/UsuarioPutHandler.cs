using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Application.Services;
using Challenge.Nubimetrics.Domain.Entities;
using Challenge.Nubimetrics.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Handlers.Usuarios
{
    public class UsuarioPutRequest : IRequest<Unit>
    {
        public UsuarioPutRequest(UserModel userModel)
        {
            this.userModel = userModel;
        }

        public UserModel userModel { get; set; }
    }

    public class UsuarioPutHandler : IRequestHandler<UsuarioPutRequest, Unit>
    {
        private readonly ILogger<UsuarioPutHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public UsuarioPutHandler(ILogger<UsuarioPutHandler> logger,
            IUserDbService service,
            IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UsuarioPutRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Actualizo usuario. usuarioID: {{userID}}, nombre: {{nombre}}, apellido: {{apellido}}, email{{email}}",request.userModel.ID, request.userModel.Nombre, request.userModel.Apellido, request.userModel.Email);

            var userEntity = mapper.Map<UserEntity>(request.userModel);
            await service.UpdateUser(userEntity);

            return Unit.Value;
        }
    }
}
