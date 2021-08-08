using Challenge.Nubimetrics.Infrastructure.Data;
using Challenge.Nubimetrics.Infrastructure.Data.Contracts;
using Challenge.Nubimetrics.Infrastructure.Models;
using Challenge.Nubimetrics.Infrastructure.Services;
using Challenge.Nubimetrics.Test.Builders;
using Challenge.Nubimetrics.Test.Mocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace Challenge.Nubimetrics.Test.Bases
{
    public abstract class ServiceBaseTest<TOptions> where TOptions : HttpOptionsBase, new ()
    {
        public ILogger Logger { get; }
        public IHttpClientFactory HttpClientFactory { get; }
        public IOptions<TOptions> Options { get; }

        protected ServiceBaseTest()
        {
            Logger = new LoggerFactory().CreateLogger<ServiceBaseTest<TOptions>>();
            HttpClientFactory = new HttpClientBuilder<TOptions>();
            Options = new OptionsMock<TOptions>(OptionsMockBuilder.GetOptions<TOptions>());
        }
    }

    public abstract class ServiceBaseTest<TContext, TEntity> where TContext : DbContext where TEntity : EntityBase
    {
        public ILogger Logger;
        public TContext DbContext { get; }
        public Repository<TContext, TEntity> Repository { get; }
        public IUnitOfWork<TContext> UnitOfWork { get; }

        protected ServiceBaseTest()
        {
            var configuration = ConfigurationTestBuilder.BuildConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<TContext>().UseSqlServer(configuration.GetSection("ConnectionStrings:ChallengeDbContext").Value);

            Logger = new LoggerFactory().CreateLogger<ServiceBaseTest<TContext, TEntity>>();
            DbContext = (TContext)Activator.CreateInstance(typeof(TContext), optionsBuilder.Options);
            Repository = new Repository<TContext, TEntity>(DbContext, false);
            UnitOfWork = new UnitOfWork<TContext>(DbContext, new QueryManager(), new UsersService());
        }
    }
}
