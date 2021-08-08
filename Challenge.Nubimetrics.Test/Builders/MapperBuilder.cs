using AutoMapper;
using Challenge.Nubimetrics.Api.Configuration;

namespace Challenge.Nubimetrics.Test.Builders
{
    public static class MapperBuilder
    {
        public static IMapper GetMapper()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapping()));
            return new Mapper(configuration);
        }
    }
}
