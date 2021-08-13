using Autofac;
using Challenge.Nubimetrics.Application.Services;
using Challenge.Nubimetrics.Application.Services.ApiServices;
using Challenge.Nubimetrics.Infrastructure.Services;

namespace Challenge.Nubimetrics.Api.Configuration
{
    public class ServicesAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<PaisesService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<BusquedaService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UsersService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserDbService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<CurrencyConversionService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<LogginService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
