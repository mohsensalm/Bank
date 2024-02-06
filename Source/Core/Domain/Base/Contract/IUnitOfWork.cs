using Domain.Base.Contract.dbo;

namespace Domain.Base.Contract;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    void RollBack();
    ILoanRepository LoanRepository { get; }
    IStatusRepository StatusRepository { get; }
}
