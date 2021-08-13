using Challenge.Nubimetrics.Domain.DataModels;
using Challenge.Nubimetrics.Domain.Options;
using Challenge.Nubimetrics.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Services
{
    public interface ICurrencyConversionServices
    {
        Task<IEnumerable<CurrencyConversionDataModel>> GetAllCurrencies();
        Task<CurrencyConversionToDolarDataModel> GetConversionToDolar(string from);
    }

    public class CurrencyConversionService : ServiceBase<MercadoLibreOptions>, ICurrencyConversionServices
    {
        public CurrencyConversionService(ILogger<ServiceBase<MercadoLibreOptions>> logger,
           IHttpClientFactory httpClientFactory,
           IOptions<MercadoLibreOptions> options)
           : base(logger, httpClientFactory, options) { }


        public async Task<IEnumerable<CurrencyConversionDataModel>> GetAllCurrencies()
        {
            logger.LogInformation("Obtengo todos las conversiones");

            string url = string.Format(Options.UrlCurrencyConversion);

            return await Get<IEnumerable<CurrencyConversionDataModel>>(url);
        }

        public async Task<CurrencyConversionToDolarDataModel> GetConversionToDolar(string from)
        {
            logger.LogInformation($"Obtengo la conversion. From: {{from}}, To: {{to}}", from, Options.IdCurrencyConversionTo);

            if (Options.IdCurrencyNotAvailable.Contains(from))
                return null;

            var url = string.Format(Options.UrlCurrencyConversionFromTo);

            return await Get<CurrencyConversionToDolarDataModel>(url, null, new KeyValuePair<string, string>("from", from), new KeyValuePair<string, string>("to", Options.IdCurrencyConversionTo));
        }
    }
}
