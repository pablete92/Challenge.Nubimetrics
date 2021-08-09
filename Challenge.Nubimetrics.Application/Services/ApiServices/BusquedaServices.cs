using Challenge.Nubimetrics.Domain.DataModels;
using Challenge.Nubimetrics.Domain.Options;
using Challenge.Nubimetrics.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Services.ApiServices
{
    public interface IBusquedaServices
    {
        Task<BusquedaDataModel> GetBusquedaByTermino(string termino);
    }

    public class BusquedaServices : ServiceBase<MercadoLibreOptions>, IBusquedaServices
    {
        public BusquedaServices(ILogger<ServiceBase<MercadoLibreOptions>> logger,
            IHttpClientFactory httpClientFactory,
            IOptions<MercadoLibreOptions> options)
            : base(logger, httpClientFactory, options) { }

        public async Task<BusquedaDataModel> GetBusquedaByTermino(string termino)
        {
            logger.LogInformation($"Obtener busqueda por termino. Termino: {{termino}}", termino);

            string url = string.Format(Options.UrlBusqueda);

            return await Get<BusquedaDataModel>(url, null, new KeyValuePair<string,string>("q", termino));
        }
    }
}
