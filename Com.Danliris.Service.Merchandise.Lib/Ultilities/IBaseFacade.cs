using Com.Danliris.Service.Merchandiser.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.Danliris.Service.Merchandiser.Lib.Ultilities
{
    public interface IBaseFacade<TModel, TViewModel> : IMap<TModel, TViewModel>
    {
        Tuple<List<TModel>, int, Dictionary<string, string>, List<string>> ReadModel(int page, int size, string order, List<string> select, string keyword, string filter);
        Task<int> CreateModel(TModel model);
        Task<TModel> ReadModelById(int id);
        Task<int> UpdateModel(int id, TModel model);
        Task<int> DeleteModel(int id);
    }
}
