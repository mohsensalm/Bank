using Domain.Base.Contract.dbo;
using Domain.Entites.dbo;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Base.Entity.dbo
{
    public  class LoanRepository : BaseRepository<Loan> , ILoanRepository
    {
        public LoanRepository(ISession session) : base(session) { }
    }
}
