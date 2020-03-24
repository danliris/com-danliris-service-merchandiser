using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Lib.Interfaces
{
    public interface IEfficiencies : IBaseFacade<Efficiency>
    {
        Task<Efficiency> ReadModelByQuantity(int Quantity);
    }
}
