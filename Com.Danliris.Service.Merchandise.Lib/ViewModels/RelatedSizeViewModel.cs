using Com.Danliris.Service.Merchandiser.Lib.Helpers;

namespace Com.Danliris.Service.Merchandiser.Lib.ViewModels
{
    public class RelatedSizeViewModel : BasicViewModel
    {
        public string Code { get; set; }
        public SizeViewModel Size { get; set; }
    }
}
