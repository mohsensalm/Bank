﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }


        public bool IsValid(BaseEntity entity)
        {
            if (entity == null)
                return false;

            else
                return true;

        }
    }
}
