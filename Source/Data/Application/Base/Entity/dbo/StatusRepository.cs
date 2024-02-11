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
    internal class StatusRepository(ISession session) : BaseRepository<Status>(session), IStatusRepository
    {
        private readonly ISession _session = session;

        public Status GetByCode(byte code)
        {

            var res = _session.Query<Status>().Where(x => x.ID == code).FirstOrDefault();
            if (res == null || res.IsValid(res) == false)

                return null;

            else

                return res;

        }

    }
}
