using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Danliris.Service.Merchandiser.Test.DataUtilities
{
    public class ArticleColorDataUtil
    {
        private readonly ArticleColorService Service;

        public ArticleColorDataUtil(ArticleColorService service)
        {
            Service = service;
        }

        public ArticleColor GetArticleColorModel()
        {
            ArticleColor TestData = new ArticleColor()
            {
                Name ="name",
                Description = "Deskription"
            };

            return TestData;
        }


        public ArticleColorViewModel GetArticleColorViewModel()
        {
            return new ArticleColorViewModel()
            {
                Name = "name",
                Description = "Deskription"
            };
        }
    }
}
