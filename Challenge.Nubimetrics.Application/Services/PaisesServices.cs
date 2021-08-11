using Challenge.Nubimetrics.Domain.DataModels;
using Challenge.Nubimetrics.Domain.Options;
using Challenge.Nubimetrics.Infrastructure.Exceptions;
using Challenge.Nubimetrics.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Challenge.Nubimetrics.Application.Services.ApiServices
{
    public interface IPaisesService
    {
        Task<PaisDataModel> GetPaisByCode(string code);
        Task<IEnumerable<PaisDataModel>> GetAllPais();
    }

    public class PaisesService : ServiceBase<MercadoLibreOptions>, IPaisesService
    {
        public PaisesService(ILogger<ServiceBase<MercadoLibreOptions>> logger,
            IHttpClientFactory httpClientFactory, IOptions<MercadoLibreOptions> options)
                : base (logger, httpClientFactory, options) {}

        public async Task<PaisDataModel> GetPaisByCode(string code)
        {
            logger.LogInformation($"Obtener Pais por codigo. Codigo: {{code}}", code);

            if (Options.PaisesUnauthorized.Contains(code.ToUpper()))
                throw new UnauthorizedAccessProyectException("error 401 unauthorized de http");

            string url = string.Format(Options.UrlPais);

            if (Options.PaisesPermitidos.Contains(code.ToUpper()))
            {
                url += $"/{code.ToUpper()}";
                var result = await Get<PaisDataModel>(url);
                logger.LogDebug($"Resultado del servicio. Result: ", result);
                return result;
            }
            
            var resultList = await Get<IEnumerable<PaisDataModel>>(url);
            logger.LogDebug($"Resultado del servicio. Result: ", resultList);
            return resultList.Where(q => q.Id == code.ToUpper()).FirstOrDefault();
        }

        public async Task<IEnumerable<PaisDataModel>> GetAllPais()
        {
            logger.LogInformation("Obtener todos los paises"); 
            string url = string.Format(Options.UrlPais);
            var result = await Get<IEnumerable<PaisDataModel>>(url);
            logger.LogDebug($"Resultado del servicio. Result: ", result);
            return result;
        }
    }
}
