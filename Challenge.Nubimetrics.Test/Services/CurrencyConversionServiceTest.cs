using Challenge.Nubimetrics.Application.Services;
using Challenge.Nubimetrics.Domain.Options;
using Challenge.Nubimetrics.Test.Bases;
using Challenge.Nubimetrics.Test.Builders;
using NUnit.Framework;

namespace Challenge.Nubimetrics.Test.Services
{
    [TestFixture]
    public class CurrencyConversionServiceTest : ServiceBaseTest<MercadoLibreOptions>
    {
        private ICurrencyConversionServices service;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<MercadoLibreOptions>.GetService<CurrencyConversionService>();
        }

        [TestCase]
        public void GetAllCurrencies()
        {
            var result = service.GetAllCurrencies().Result;

            Assert.IsNotNull(result);
        }

        [TestCase("ARS", "USD")]
        public void GetAllCurrencies(string from, string to)
        {
            var result = service.GetConversionToDolar(from).Result;

            Assert.IsNotNull(result);
        }
    }
}
