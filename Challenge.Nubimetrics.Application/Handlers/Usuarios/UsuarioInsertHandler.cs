using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Application.Services;
using Challenge.Nubimetrics.Domain.Entities;
using Challenge.Nubimetrics.Infrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Handlers.Usuarios
{
    public class UsuarioInsertRequest : IRequest<Unit>
    {
        public UsuarioInsertRequest(UserModel userModel)
        {
            this.UserModel = userModel;
        }
        public UserModel UserModel { get; }
    }

    public class UsuarioInsertHandler : IRequestHandler<UsuarioInsertRequest, Unit>
    {
        private readonly ILogger<UsuarioInsertHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public UsuarioInsertHandler(ILogger<UsuarioInsertHandler> logger,
            IUserDbService service,
            IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UsuarioInsertRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Agrego usuario a base de datos: Usuario.Nombre: {{nombre}}, Apellido: {{apellido}}, email: {{email}}",request.UserModel.Nombre, request.UserModel.Apellido, request.UserModel.Email);

            var userEntity = mapper.Map<UserEntity>(request.UserModel);

            await service.InsertUser(userEntity);

            if (userEntity.ID == 0)
                throw new NotFoundProjectException("No se pudo insertar el usuario");

            return Unit.Value;
        }
    }
}
