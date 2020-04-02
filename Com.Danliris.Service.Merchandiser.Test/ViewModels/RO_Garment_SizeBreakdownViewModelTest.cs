using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.ViewModels
{
    public class RO_Garment_SizeBreakdownViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate_RO_Garment_SizeBreakdownViewModel()
        {
            
            string Code = "Code test";
            ArticleColorViewModel Color = new ArticleColorViewModel();

            int Total = 1;
            List<RO_Garment_SizeBreakdown_DetailViewModel> RO_Garment_SizeBreakdown_Details = new List<RO_Garment_SizeBreakdown_DetailViewModel>
            {

            };
            var rogsvm = new RO_Garment_SizeBreakdownViewModel();
            rogsvm.Code = Code;
            rogsvm.Color = Color;
            rogsvm.Total = Total;
            rogsvm.RO_Garment_SizeBreakdown_Details = RO_Garment_SizeBreakdown_Details;

            Assert.Equal(Code, rogsvm.Code);
            Assert.Equal(Color, rogsvm.Color);
            Assert.Equal(RO_Garment_SizeBreakdown_Details, rogsvm.RO_Garment_SizeBreakdown_Details);
            Assert.Equal(Total, rogsvm.Total);
        }
       

    }
}
