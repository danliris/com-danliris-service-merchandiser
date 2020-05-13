using Com.Danliris.Service.Merchandiser.Lib;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.Services;
using Com.Danliris.Service.Merchandiser.Lib.Ultilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Services
{
   public class CostCalculationGarment_MaterialServiceTest
    {

        private const string ENTITY = "CostCalculationGarment_MaterialService";

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetCurrentMethod()
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);

            return string.Concat(sf.GetMethod().Name, "_", ENTITY);
        }

        private MerchandiserDbContext _dbContext(string testName)
        {
            DbContextOptionsBuilder<MerchandiserDbContext> optionsBuilder = new DbContextOptionsBuilder<MerchandiserDbContext>();
            optionsBuilder
                .UseInMemoryDatabase(testName)
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            MerchandiserDbContext dbContext = new MerchandiserDbContext(optionsBuilder.Options);

            return dbContext;
        }

        public Mock<IServiceProvider> GetServiceProvider(string testname)
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(s => s.GetService(typeof(MerchandiserDbContext)))
                .Returns(_dbContext(testname));

            serviceProvider
              .Setup(x => x.GetService(typeof(IIdentityService)))
              .Returns(new IdentityService() { Token = "Token", Username = "username" });

            return serviceProvider;
        }

        [Fact]
        public void ReadModel_Return_Success()
        {
            string testName = GetCurrentMethod();
            var dbContext = _dbContext(testName);
            CostCalculationGarment_MaterialService CostCalculationGarment_MaterialsObj = new CostCalculationGarment_MaterialService(GetServiceProvider(testName).Object);
            dbContext.CostCalculationGarment_Materials.Add(new Lib.Models.CostCalculationGarment_Material() { Id = 1, Active = true, Code = "Code test" });
            dbContext.SaveChanges();
            var result = CostCalculationGarment_MaterialsObj.ReadModel(1, 25, "{}", new List<string>() { "select" }, "keyword test", "{}");
            Assert.NotNull(result);
            Assert.NotEqual(0, dbContext.CostCalculationGarment_Materials.Count());


        }

       

        [Fact]
        public async Task CreateModel_Return_Success()
        {
            string testName = GetCurrentMethod();

            CostCalculationGarment_Material model = new CostCalculationGarment_Material()
            {
                Code = "any code"
            };
            CostCalculationGarment_MaterialService CostCalculationGarment_MaterialObj = new CostCalculationGarment_MaterialService(GetServiceProvider(testName).Object);

          // var result = await CostCalculationGarment_MaterialObj.CreateModel(model);
            await Assert.ThrowsAsync<NotImplementedException>(() => CostCalculationGarment_MaterialObj.CreateModel(model));
        }

        //[Fact]
        //public void Should_Success_OnCreating()
        //{
        //    string testName = GetCurrentMethod();

        //    CostCalculationGarment_Material model = new CostCalculationGarment_Material()
        //    {
        //        Code = "any code"
        //    };
        //    CostCalculationGarment_MaterialService RateServiceObj = new CostCalculationGarment_MaterialService(GetServiceProvider(testName).Object);

        //    RateServiceObj.OnCreating(model);
        //}


    }
}
