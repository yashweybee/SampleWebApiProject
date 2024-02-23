using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDAL.ViewModels
{
    public class VMBooksSP
    {
        public string? Search { get; set; }
        public string? SortColumn { get; set; }
        public string? SortType { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}
