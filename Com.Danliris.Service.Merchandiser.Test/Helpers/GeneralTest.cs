using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
  public  class GeneralTest
    {
        [Fact]
       public void TransformOrderBy_With_delete_Return_Success()
        {
            string order = "_deleted";
            string TransformOrder = "_IsDeleted";
            string result = General.TransformOrderBy(order);
            Assert.Equal(TransformOrder, result);
        }

        [Fact]
        public void TransformOrderBy_With_active_Return_Success()
        {
            string order = "_active";
            string TransformOrder = "Active";
            string result = General.TransformOrderBy(order);
            Assert.Equal(TransformOrder, result);
        }

        [Fact]
        public void TransformOrderBy_With_createdDate_Return_Success()
        {
            string order = "_createdDate";
            string TransformOrder = "_CreatedUtc";
            string result = General.TransformOrderBy(order);
            Assert.Equal(TransformOrder, result);
        }
        [Fact]
        public void TransformOrderBy_With_createdBy_Return_Success()
        {
            string order = "_createdBy";
            string TransformOrder = "_CreatedBy";
            string result = General.TransformOrderBy(order);
            Assert.Equal(TransformOrder, result);
        }
        [Fact]
        public void TransformOrderBy_With_createdAgent_Return_Success()
        {
            string order = "_createdAgent";
            string TransformOrder = "_CreatedAgent";
            string result = General.TransformOrderBy(order);
            Assert.Equal(TransformOrder, result);
        }
        [Fact]
        public void TransformOrderBy_With_updatedDate_Return_Success()
        {
            string order = "_updatedDate";
            string TransformOrder = "_LastModifiedUtc";
            string result = General.TransformOrderBy(order);
            Assert.Equal(TransformOrder, result);
        }

        [Fact]
        public void TransformOrderBy_With_updatedBy_Return_Success()
        {
            string order = "_updatedBy";
            string TransformOrder = "_LastModifiedBy";
            string result = General.TransformOrderBy(order);
            Assert.Equal(TransformOrder, result);
        }

        [Fact]
        public void TransformOrderBy_With_updateAgent_Return_Success()
        {
            string order = "_updateAgent";
            string TransformOrder = "_LastModifiedAgent";
            string result = General.TransformOrderBy(order);
            Assert.Equal(TransformOrder, result);
        }

        [Fact]
        public void TransformOrderBy_With_Null_order_Return_Null()
        {
            string order = null;
            string result = General.TransformOrderBy(order);
            Assert.Null(result);
        }

        [Fact]
        public void TransformOrderBy_With_undefined_order_Return_Undifined()
        {
            string order = "undifined";
            string result = General.TransformOrderBy(order);
            Assert.Equal(order,result);
        }

        [Fact]
        public void BuildSearch_Return_Success()
        {
            List<string> SearchAttributes = new List<string>() {"select"};

            string result = General.BuildSearch(SearchAttributes);
            Assert.NotEmpty(result);
        }

       
    }

}
