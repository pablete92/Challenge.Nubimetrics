using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Application.Services.ApiServices;
using Challenge.Nubimetrics.Infrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Handlers.Paises
{
    public class PaisGetByCodeRequest : IRequest<PaisModel>
    {
        public PaisGetByCodeRequest(string code)
        {
            this.Code = code;
        }
        public string Code { get; }
    }

    public class PaisGetByCodeHandlers : IRequestHandler<PaisGetByCodeRequest, PaisModel>
    {
        private readonly ILogger<PaisGetByCodeHandlers> logger;
        private readonly IPaisesService service;
        private readonly IMapper mapper;

        public PaisGetByCodeHandlers(ILogger<PaisGetByCodeHandlers> logger,
            IPaisesService service,
            IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<PaisModel> Handle(PaisGetByCodeRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Obtener pais por el codigo. Codigo: {{code}}", request.Code);

            if (string.IsNullOrWhiteSpace(request.Code))
                throw new BadRequestProjectException("Debe ingresar un codigo de pais.");

            var result = await service.GetPaisByCode(request.Code);

            if (result == null)
                throw new NotFoundProjectException("Codigo de pais invalido.");

            return mapper.Map<PaisModel>(result);
        }
    }
}
