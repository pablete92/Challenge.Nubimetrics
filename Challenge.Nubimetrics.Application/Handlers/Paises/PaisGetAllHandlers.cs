using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Application.Services.ApiServices;
using Challenge.Nubimetrics.Infrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Handlers.Paises
{
    public class PaisGetAllRequest : IRequest<IEnumerable<PaisModel>>
    {
    }

    public class PaisGetAllHandlers : IRequestHandler<PaisGetAllRequest, IEnumerable<PaisModel>>
    {
        private readonly ILogger<PaisGetAllHandlers> logger;
        private readonly IPaisesService service;
        private readonly IMapper mapper;

        public PaisGetAllHandlers(ILogger<PaisGetAllHandlers> logger,
            IPaisesService service,
            IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PaisModel>> Handle(PaisGetAllRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Obtener todos los paises ");

            var result = await service.GetAllPais();

            if (result == null)
                throw new NotFoundProjectException("No hay paises");

            return mapper.Map<IEnumerable<PaisModel>>(result);
        }
    }
}
