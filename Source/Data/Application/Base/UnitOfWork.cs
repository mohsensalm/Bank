using Application.Base.Entity.dbo;
using Domain.Base.Contract;
using Domain.Base.Contract.dbo;
using NHibernate;

namespace Application.Base;

public class UnitOfWork : IUnitOfWork
{

    private readonly ISessionFactory _sessionFactory;

    private readonly ITransaction _transaction;

    private readonly ISession _session;

    public UnitOfWork(ISessionFactory sessionFactory)
    {
        _sessionFactory = sessionFactory;

        _session = _sessionFactory.OpenSession();

        _transaction = _session.BeginTransaction();
    }

    private ILoanRepository _LoanRepository = null!;
    private IStatusRepository _StatusRepository = null!;

    public ILoanRepository LoanRepository
    {
        get
        {
            _LoanRepository ??= new LoanRepository(_session);
            return _LoanRepository;
        }
    }

    public IStatusRepository StatusRepository
    {
        get
        {
            _StatusRepository ??= new StatusRepository(_session);
            return _StatusRepository;
        }
    }

    public void Commit()
    {
        if (!_transaction.IsActive)
        {
            throw new InvalidOperationException("No active transation");
        }

        _transaction.Commit();
    }

    public void Dispose()
    {
        if (_session.IsOpen)
        {
            _session.Close();
        }
    }

    public void RollBack()
    {
        if (_transaction.IsActive)
        {
            _transaction.Rollback();
        }
    }
}