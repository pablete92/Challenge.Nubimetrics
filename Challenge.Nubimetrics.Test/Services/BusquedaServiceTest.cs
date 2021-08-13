using Challenge.Nubimetrics.Application.Services.ApiServices;
using Challenge.Nubimetrics.Domain.Options;
using Challenge.Nubimetrics.Test.Bases;
using Challenge.Nubimetrics.Test.Builders;
using NUnit.Framework;

namespace Challenge.Nubimetrics.Test.Services.ApiServices
{
    [TestFixture]
    public class BusquedaServiceTest : ServiceBaseTest<MercadoLibreOptions>
    {
        private IBusquedaServices service;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<MercadoLibreOptions>.GetService<BusquedaService>();
        }

        //[TestCase("Iphone")]
        //public void GetBusquedaByTermino(string termino)
        //{
        //    var result = service.GetBusquedaByTermino(termino).Result;

        //    Assert.IsNotNull(result);
        //}
    }
}
