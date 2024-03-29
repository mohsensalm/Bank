﻿using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites.dbo
{
    public class Loan : BaseEntity
    {
        public Loan()
        {
            Name = string.Empty;
            Description = string.Empty;
            PricePerIns = string.Empty;
        }
        public virtual int ID { get; set; }
        public virtual int CoferID { get; set; }
        public virtual string Name { get; set; }
        public virtual int Admin { get; set; }
        public virtual int TotalPrice { get; set; }
        public virtual int InstallmentNum { get; set; }
        public virtual int MemberNum { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual int Status { get; set; }
        public virtual string Description { get; set; }
        public virtual string PricePerIns { get; set; }


        public override string ToString()
        {
            return $"{ID}{Name}";
        }

    }
}
