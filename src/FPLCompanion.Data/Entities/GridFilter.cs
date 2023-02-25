using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLCompanion.Data.Entities
{
    public class GridFilter
    {
        public long GridFilterId { get; set; }

        public string GridKey { get; set;}

        public string Filter { get; set; }
    }
}
