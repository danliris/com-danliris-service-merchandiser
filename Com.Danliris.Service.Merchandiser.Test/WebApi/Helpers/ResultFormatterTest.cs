using AutoMapper;
using Com.Danliris.Service.Merchandiser.Lib.Exceptions;
using Com.Danliris.Service.Merchandiser.Lib.Models;
using Com.Danliris.Service.Merchandiser.Lib.ViewModels;
using Com.Danliris.Service.Merchandiser.WebApi.Helpers;
using Com.Moonlay.NetCore.Lib.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Com.Danliris.Service.Merchandiser.Test.WebApi.Helpers
{
    public class ResultFormatterTest
    {
        [Fact]
        public void OK_with_DataModel_Return_Success()
        {


            ResultFormatter resultFormatter = new ResultFormatter("ApiVersion 1", 200, "Oke Good");

            var Data = new Line() { Id = 26 };
            var dataVM = new List<LineViewModel>()
            {
                new LineViewModel()
                {
                    Id=26
                }
            };
            var result = resultFormatter.Ok(Data, dataVM);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void OK_with_ListDataModel_Return_Success()
        {


            ResultFormatter resultFormatter = new ResultFormatter("ApiVersion 1", 200, "Oke Good");

            var Data = new List<Line>(){
                new Line() { Id = 26 } };

            Func<Line, LineViewModel> MapToViewModel = (Line) => new LineViewModel() { };



            var result = resultFormatter.Ok(Data, MapToViewModel);
            Assert.NotEmpty(result);
        }


        [Fact]
        public void Should_Success_OK_With_Mapper()
        {
            ResultFormatter resultFormatter = new ResultFormatter("ApiVersion 1", 200, "Oke Good");

            var mappingService = new Mock<IMapper>();

            var Data = new List<Line>(){
                new Line() {
                    Id = 26,
                    Code="code line",
                }
            };

           

            var order = new Dictionary<string, string>()
        {
            { "element 1", "element2" }

        };

            List<string> Select = new List<string>()
            {
                "Code",
            };

            var result = resultFormatter.Ok(mappingService.Object,Data, 1, 1, 1, 1, order, Select);
            Assert.NotEmpty(result);


        }

        [Fact]
        public void Should_Success_OK_With_Select_()
        {
            ResultFormatter resultFormatter = new ResultFormatter("ApiVersion 1", 200, "Oke Good");

            var Data = new List<Line>(){
                new Line() {
                    Id = 26,
                    Code="code line",
                } 
            };

            Func<Line, LineViewModel> MapToViewModel = (Line) => new LineViewModel() { };

            var order = new Dictionary<string, string>()
        {
            { "element 1", "element2" }

        };

            List<string> Select = new List<string>()
            {
                "Code",
            };

            var result = resultFormatter.Ok(Data, MapToViewModel, 1, 1, 1, 1, order, Select);
            Assert.NotEmpty(result);


        }



        [Fact]
        public void Should_Success_OK_With_Select_Empty()
        {
            ResultFormatter resultFormatter = new ResultFormatter("ApiVersion 1", 200, "Oke Good");

            var Data = new List<Line>(){
                new Line() {
                    Id = 26,
                    Code="code line",
                }
            };

            Func<Line, LineViewModel> MapToViewModel = (Line) => new LineViewModel() { };

            var order = new Dictionary<string, string>()
        {
            { "element 1", "element2" }

        };

            List<string> Select = new List<string>()
            {
                //"Code",
            };

            var result = resultFormatter.Ok(Data, MapToViewModel, 1, 1, 1, 1, order, Select);
            Assert.NotEmpty(result);


        }


        [Fact]
        public void OK_with_Delegate_View_Data_Model_Return_Success()
        {


            ResultFormatter resultFormatter = new ResultFormatter("ApiVersion 1", 200, "Oke Good");

            var Data = new Line() { Id = 26 };

            Func<Line, LineViewModel> MapToViewModel = (Line) => new LineViewModel() { };



            var result = resultFormatter.Ok(Data, MapToViewModel);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void Fail_Return_Exception()
        {
            ResultFormatter resultFormatter = new ResultFormatter("ApiVersion 1", 200, "Oke Good");

            var exception = new Mock<DbReferenceNotNullException>();

            var result = resultFormatter.Fail(exception.Object);
            Assert.NotEmpty(result);
        }

    }
}
