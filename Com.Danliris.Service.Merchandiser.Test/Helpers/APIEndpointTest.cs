using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
   public class APIEndpointTest
    {
        [Fact]
        public void Should_Success_Instantiate_APIEndpoint()
        {
            string core = "core test";
            string inventory = "Inventory test";
            string production = "Production test";
            string purchasing = "Purchasing test";
            APIEndpoint.Core = core;
            APIEndpoint.Inventory = inventory;
            APIEndpoint.Production = production;
            APIEndpoint.Purchasing = purchasing;

            Assert.Equal(core, APIEndpoint.Core);
            Assert.Equal(inventory, APIEndpoint.Inventory);
            Assert.Equal(production, APIEndpoint.Production);
            Assert.Equal(purchasing, APIEndpoint.Purchasing);
        }

    }
}
