using Autofac;
using Challenge.Nubimetrics.Domain.Contexts;
using Challenge.Nubimetrics.Infrastructure.Data;
using Challenge.Nubimetrics.Infrastructure.Data.Contracts;
using Challenge.Nubimetrics.Infrastructure.Models;
using Challenge.Nubimetrics.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Nubimetrics.Api.Configuration
{
    public class DataAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ChallengeDbContext>()
                .As(typeof(DbContext))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(UnitOfWork<>))
                .As(typeof(IUnitOfWork<>))
                .InstancePerLifetimeScope();

            builder.RegisterType<StoredProcedureRepository<ChallengeDbContext>>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<QueryManager>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ChannelBuilder>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(SoapMapper<>))
                .As(typeof(ISoapMapper<>))
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepositoryQuery<,>))
                .WithParameter("traking", false);

            builder.RegisterGeneric(typeof(Repository<,>))
                .As(typeof(IRepositoryCommand<,>))
                .WithParameter("traking", false);
        }
    }
}
