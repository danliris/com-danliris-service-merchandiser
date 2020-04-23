using Com.Danliris.Service.Merchandiser.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Lib.Interfaces
{
    public interface ICostCalculationGarment_MaterialService
    {
        IEnumerable<CostCalculationGarment_Material> DbSet { get; }

        Task UpdateModel(int id, CostCalculationGarment_Material costCalculationGarment_Material);
    }
}
