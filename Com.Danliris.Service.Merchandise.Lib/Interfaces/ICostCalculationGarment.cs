using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Lib.Interfaces
{
    public interface ICostCalculationGarments : IBaseFacade<CostCalculationGarment>
    {
        CostCalculationGarmentViewModel MapToViewModel(CostCalculationGarment costCalculationGarment);
        CostCalculationGarment MapToModel(CostCalculationGarmentViewModel costCalculationGarment);
        Task<CostCalculationGarment> ReadModelById(int costCalculationGarmentId);
    }
}
