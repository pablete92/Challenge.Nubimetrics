using Challenge.Nubimetrics.Infrastructure.Models;

namespace Challenge.Nubimetrics.Domain.Options
{
    public  class MercadoLibreOptions : HttpOptionsBase
    {
        public MercadoLibreOptions() : base() { }

        public string UrlPais { get; set; }
        public string UrlBusqueda { get; set; }
        public string[] PaisesPermitidos { get; set; }
        public string[] PaisesUnauthorized { get; set; }
    }
}
