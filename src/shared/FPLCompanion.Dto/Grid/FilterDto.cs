using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPLCompanion.Dto.Grid
{
    public class FilterDto
    {
        public long GridFilterId { get; set; }

        public string GridKey { get; set; }

        public string Filter { get; set; }
    }
}
