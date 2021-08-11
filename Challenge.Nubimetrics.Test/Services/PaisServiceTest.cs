using Challenge.Nubimetrics.Application.Services.ApiServices;
using Challenge.Nubimetrics.Domain.Options;
using Challenge.Nubimetrics.Test.Bases;
using Challenge.Nubimetrics.Test.Builders;
using NUnit.Framework;

namespace Challenge.Nubimetrics.Test.Services.ApiServices
{
    [TestFixture]
    public class PaisServiceTest : ServiceBaseTest<MercadoLibreOptions>
    {
        private IPaisesService service;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<MercadoLibreOptions>.GetService<PaisesService>();
        }

        //[TestCase("AR")]
        //public void GetPaisByCodeTestAR(string code)
        //{
        //    var result = service.GetPaisByCode(code).Result;

        //    Assert.IsNotNull(result);
        //}

        //[TestCase("BR")]
        //public void GetPaisByCodeTestBR(string code)
        //{
        //    var result = service.GetPaisByCode(code).Result;

        //    Assert.IsNotNull(result);
        //}

        //[TestCase("CO")]
        //public void GetPaisByCodeTestCO(string code)
        //{
        //    var result = service.GetPaisByCode(code).Result;

        //    Assert.IsNotNull(result);
        //}

        //[TestCase("CN")]
        //public void GetPaisByCodeTestCN(string code)
        //{
        //    var result = service.GetPaisByCode(code).Result;

        //    Assert.IsNotNull(result);
        //}

        //[TestCase()]
        //public void GetAllPais()
        //{
        //    var result = service.GetAllPais().Result;

        //    Assert.IsNotNull(result);
        //}
    }
}
