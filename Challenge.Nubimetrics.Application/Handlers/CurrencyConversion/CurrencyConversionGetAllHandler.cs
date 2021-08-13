using AutoMapper;
using Challenge.Nubimetrics.Application.Models;
using Challenge.Nubimetrics.Application.Services;
using Challenge.Nubimetrics.Infrastructure.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Handlers.CurrencyConversion
{
    public class CurrencyConversionGetAllRequest : IRequest<IEnumerable<CurrencyConversionModel>>
    {
    }

    public class CurrencyConversionGetAllHandler : IRequestHandler<CurrencyConversionGetAllRequest, IEnumerable<CurrencyConversionModel>>
    {
        private readonly ILogger<CurrencyConversionGetAllHandler> logger;
        private readonly ICurrencyConversionServices service;
        private readonly ILogginService serviceLoggin;
        private readonly IMapper mapper;

        public CurrencyConversionGetAllHandler(ILogger<CurrencyConversionGetAllHandler> logger,
            ICurrencyConversionServices service,
            ILogginService serviceLoggin,
            IMapper mapper)
        {
            this.logger = logger;
            this.service = service;
            this.serviceLoggin = serviceLoggin;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CurrencyConversionModel>> Handle(CurrencyConversionGetAllRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Obtener todas las conversiones");

            var result = await service.GetAllCurrencies();

            if (result == null)
                throw new NotFoundProjectException("No hay conversiones");

            foreach (var currency in result)
            {
                logger.LogInformation($"Obtengo la conversion para el ID: {{Id}}", currency.Id);
                currency.ToDolar = await service.GetConversionToDolar(currency.Id);
            }

            await serviceLoggin.WriteDisk(result);

            return mapper.Map<IEnumerable<CurrencyConversionModel>>(result);
        }
    }
}
