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
    internal class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        private ISession session;

        public StatusRepository(ISession session)
        {
            this.session = session;
        }
    }
}
