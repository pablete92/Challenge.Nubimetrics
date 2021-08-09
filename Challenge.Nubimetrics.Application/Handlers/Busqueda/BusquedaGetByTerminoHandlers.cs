using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Application.Services.ApiServices;
using Challenge.Nubimetrics.Infrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Handlers.Busqueda
{
    public class BusquedaGetByTerminoRequest : IRequest<BusquedaModel>
    {
        public BusquedaGetByTerminoRequest(string termino)
        {
            this.Termino = termino;
        }
        public string Termino { get; set; }
    }
    
    public class BusquedaGetByTerminoHandlers : IRequestHandler<BusquedaGetByTerminoRequest, BusquedaModel>
    {
        private readonly ILogger<BusquedaGetByTerminoHandlers> logger;
        private readonly IBusquedaServices service;
        private readonly IMapper mapper;

        public BusquedaGetByTerminoHandlers(ILogger<BusquedaGetByTerminoHandlers> logger,
            IBusquedaServices service,
            IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<BusquedaModel> Handle(BusquedaGetByTerminoRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Obtener busqueda por termino. Termino: {{termino}}", request.Termino);

            if (string.IsNullOrWhiteSpace(request.Termino))
                throw new BadRequestProjectException("Debe ingresar un termino de busqueda.");

            var result = await service.GetBusquedaByTermino(request.Termino);

            if (result == null)
                throw new NotFoundProjectException("Termino de busqueda invalido.");

            return mapper.Map<BusquedaModel>(result);
        }
    }
}
