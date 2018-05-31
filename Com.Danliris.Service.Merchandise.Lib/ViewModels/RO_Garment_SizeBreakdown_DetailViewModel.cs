using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Lib.ViewModels
{
    public class RO_Garment_SizeBreakdown_DetailViewModel : BasicViewModel
    {
        public string Code { get; set; }
        public string Information { get; set; }
        public string Size { get; set; }
        public int? Quantity { get; set; }
    }
}
