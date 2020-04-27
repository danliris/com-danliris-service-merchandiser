using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Lib.Interfaces
{
    public interface ICostCalculationGarment_Material : IBaseFacade<CostCalculationGarment_Material>
    {
        IEnumerable<CostCalculationGarment_Material> DbSet { get; }

        Task UpdateModel(int id, CostCalculationGarment_Material costCalculationGarment_Material);
    }
    //public interface ICostCalculationGarment_MaterialService
    //{
    //    IEnumerable<CostCalculationGarment_Material> DbSet { get; }

    //    Task UpdateModel(int id, CostCalculationGarment_Material costCalculationGarment_Material);
    //}
}
