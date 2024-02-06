using Domain.Entites.dbo;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Configuration;

namespace Bank.EndPoint.App.Infra;

public static class NHibernateExtensions
{
    public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
    {
        var mapper = new ModelMapper();
        mapper.AddMappings(typeof(NHibernateExtensions).Assembly.ExportedTypes);
        HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

        //var config = new NHibernate.Cfg.Configuration();
        //config.AddAssembly("Persistence");

        var configuration = new NHibernate.Cfg.Configuration();
        configuration.DataBaseIntegration(c =>
        {
            //c.Driver<MicrosoftDataSqlClientDriver>();
            c.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
            c.ConnectionString = connectionString;
            //c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
            //c.SchemaAction = SchemaAutoAction.Validate;
            //c.LogFormattedSql = true;
            //c.LogSqlInConsole = true;
        });
        configuration.AddMapping(domainMapping);

        var sessionFactory = configuration.BuildSessionFactory();

        services.AddSingleton(sessionFactory);
        services.AddScoped(factory => sessionFactory.OpenSession());


        return services;
    }
}

