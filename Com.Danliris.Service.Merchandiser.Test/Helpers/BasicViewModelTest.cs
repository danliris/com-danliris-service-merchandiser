using Com.Danliris.Service.Merchandiser.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.Helpers
{
    public class BasicViewModelTest
    {
        [Fact]
        public void Should_Success_Instantiate()
        {
            int id = 1;
            bool _isDeleted = true;
            bool active = true;
            DateTime _createdUtc = DateTime.Now;
            string _createdBy = "createby test";
            string _createdAgent = "_createdAgent test";
            DateTime _lastModifiedUtc = DateTime.Now.AddDays(-1);
            string _lastModifiedBy = "somebody test";
            string _lastModifiedAgent = "somebody test";

            var bvm = new BasicViewModel();

            bvm.Id = id;
            bvm._IsDeleted = _isDeleted;
            bvm.Active = active;
            bvm._CreatedUtc = _createdUtc;
            bvm._CreatedBy = _createdBy;
            bvm._CreatedAgent = _createdAgent;
            bvm._LastModifiedUtc = _lastModifiedUtc;
            bvm._LastModifiedBy = _lastModifiedBy;
            bvm._LastModifiedAgent = _lastModifiedAgent;

            Assert.Equal(id, bvm.Id);
            Assert.Equal(active, bvm.Active);
            Assert.Equal(_isDeleted, bvm._IsDeleted);
            Assert.Equal(_createdUtc, bvm._CreatedUtc);
            Assert.Equal(_createdBy, bvm._CreatedBy);
            Assert.Equal(_createdAgent, bvm._CreatedAgent);
            Assert.Equal(_lastModifiedUtc, bvm._LastModifiedUtc);
            Assert.Equal(_lastModifiedBy, bvm._LastModifiedBy);
            Assert.Equal(_lastModifiedAgent, bvm._LastModifiedAgent);
        }
    }
}
