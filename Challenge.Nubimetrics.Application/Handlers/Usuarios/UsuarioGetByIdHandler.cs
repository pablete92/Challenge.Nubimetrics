using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Application.Services;
using Challenge.Nubimetrics.Infrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Handlers.Usuarios
{
    public class UsuarioGetByIdRequest : IRequest<UserModel>
    {
        public UsuarioGetByIdRequest(int Id)
        {
            this.Id = Id;
        }

        public int Id { get; }
    }
    public class UsuarioGetByIdHandler : IRequestHandler<UsuarioGetByIdRequest, UserModel>
    {
        private readonly ILogger<UsuarioGetByIdHandler> logger;
        private readonly IUserDbService service;
        private readonly IMapper mapper;

        public UsuarioGetByIdHandler(ILogger<UsuarioGetByIdHandler> logger, IUserDbService service, IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<UserModel> Handle(UsuarioGetByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
                throw new NotFoundProjectException("Id de usuario invalido.");


            logger.LogInformation($"Obtener el usuario. Id: {{Id}}", request.Id);
            var result = await service.GetByID(request.Id);

            if (result == null)
                throw new NotFoundProjectException("No se encontraron usuarios.");

            return mapper.Map<UserModel>(result);
        }
    }
}
