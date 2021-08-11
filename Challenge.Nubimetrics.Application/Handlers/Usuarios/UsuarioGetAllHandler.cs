using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Application.Services;
using Challenge.Nubimetrics.Infrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Handlers.Usuarios
{
    public class UsuarioGetAllRequest : IRequest<IEnumerable<UserModel>> { }

    public class UsuarioGetAllHandler : IRequestHandler<UsuarioGetAllRequest, IEnumerable<UserModel>>
    {
        private readonly ILogger<UsuarioGetAllHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public UsuarioGetAllHandler(ILogger<UsuarioGetAllHandler> logger, IUserDbService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserModel>> Handle(UsuarioGetAllRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Obtener todos los usuarios");
            var result = await service.GetAllUser();

            if (result == null)
                throw new NotFoundProjectException("No se encontraron usuarios.");

            return mapper.Map<IEnumerable<UserModel>>(result);
        }
    }
}
