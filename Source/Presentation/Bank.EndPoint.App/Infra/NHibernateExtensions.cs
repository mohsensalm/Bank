using Domain.Entites.dbo;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
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

        var config = new NHibernate.Cfg.Configuration();
        config.AddAssembly("Persistence");

        var configuration = new NHibernate.Cfg.Configuration();
        configuration.DataBaseIntegration(c =>
        {
            c.Dialect<NHibernate.Dialect.MsSql2012Dialect>();
            c.ConnectionString = connectionString;
            c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
            c.SchemaAction = SchemaAutoAction.Validate;
            c.LogFormattedSql = true;
            c.LogSqlInConsole = true;
        });
        configuration.AddMapping(domainMapping);

        var sessionFactory = configuration.BuildSessionFactory();

        services.AddSingleton(sessionFactory);
        services.AddScoped(factory => sessionFactory.OpenSession());


        return services;
    }
}

public abstract class BaseEntity
{

}

public interface  IBAseEntity
{

}


public interface ILoanRepository : IGenericRepository<Loan>
{
    bool IsAvilable(); 
}

public class LoanRepository : BaseRepository<Loan>, ILoanRepository
{
    public bool IsAvilable()
    {
        throw new NotImplementedException();
    }
}

public interface IStatusRepository
{
    //empty
}



public class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity    ///  BAseEntity ,IBAseEntity  ,
{
    public BaseRepository()
    {
            
    }
    public void Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Edit(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetAll()
    {
        throw new NotImplementedException();
    }
}

public interface IGenericRepository<TEntity> where TEntity : BaseEntity 
{
    void Add(TEntity entity);

    void Edit(TEntity entity);

    TEntity Get(int id);

    bool Delete(int id );

    IQueryable<TEntity> GetAll();


}



interface IUnitOFWork
{
    void Save();
    void Comite();
    void RoleBack();
}

class UnitOfWork : IUnitOFWork
{
    public ILoanRepository  loanRepository { get; }

    

    public void Comite()
    {
        throw new NotImplementedException();
    }

    public void RoleBack()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}