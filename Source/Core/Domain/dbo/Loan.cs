using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.dbo
{
    public class Loan
    {
        public virtual int ID { get; set; }
        public virtual int CoferID { get; set; }
        public virtual string? Name { get; set; }
        public virtual int Admin { get; set; }
        public virtual int TotalPrice { get; set; }
        public virtual int InstallmentNum { get; set; }
        public virtual int MemberNum { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int Status { get; set; }
        public virtual string? Description { get; set; }
        public virtual string? PricePerIns { get; set; }




    }
}
