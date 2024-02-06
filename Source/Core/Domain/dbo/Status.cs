using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.dbo
{
     public class Status
    {
        public Status()
        {
            Title=string.Empty;
        }
        public int ID { get; set; }
        public int SatusType  { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return $"{Title}";
        }
    }
}
