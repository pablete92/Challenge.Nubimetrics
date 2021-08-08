using Challenge.Nubimetrics.Domain.Options;
using Challenge.Nubimetrics.Test.Builders;
using Microsoft.Extensions.Configuration;

namespace Challenge.Nubimetrics.Test.Bases
{
    public static class OptionsMockBuilder
    {
        public static TOptions GetOptions<TOptions>() where TOptions : class
        {
            var configuration = ConfigurationTestBuilder.BuildConfiguration();

            if (typeof(TOptions) == typeof(MercadoLibreOptions))
            {
                var section = configuration.GetSection("MercadoLibre").Get<MercadoLibreOptions>();
                return section as TOptions;
            }

            return null;
        }
    }
}
