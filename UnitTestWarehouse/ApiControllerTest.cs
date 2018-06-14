using Moq;
using System;
using System.Collections.Generic;
using WarehouseManagement.Controllers;
using WarehouseManagement.Data;
using WarehouseManagement.Models;
using Xunit;

namespace UnitTestWarehouse
{
    public class ApiControllerTest
    {
        [Fact]
        public void ApiController_TryGetAllDataIfEmpty_Success()
        {
            var mock = new Mock<IApiRequestSend<Product>>();
            var apiControllerMock = new ApiController(mock.Object);

            apiControllerMock.GetAllData();
            mock.Verify(m => m.GetAllData(), Times.Once);
        }

        [Fact]
        public void ApiController_TryGetAllDataFromList_Success()
        {
            var mock = new Mock<IApiRequestSend<Product>>();
            IEnumerable<Product> products = new[]
            {
                new Product()
                {
                    Id = 1,
                    Name = "Bio-Hazard Gem 101",
                    Price = 1000,
                    Quantity = 100,
                    Section = "Chem-Section"
                },
                 new Product()
                {
                    Id = 2,
                    Name = "Bicycle",
                    Price = 5000,
                    Quantity = 10,
                    Section = "Section-A"
                },
                   new Product()
                {
                    Id = 3,
                    Name = "Babyseat",
                    Price = 3000,
                    Quantity = 10,
                    Section = "Section-B"
                }

            };

            var apiControllerMock = new ApiController(mock.Object);
            mock.Setup(m => m.GetAllData()).Returns(products);

            var actualObjects = mock.Object.GetAllData();
            var expectedObjects = products;

            Assert.Equal(expectedObjects, actualObjects);

        }

        [Fact]
        public void ApiController_TryAddEntity_Success()
        {
            var product = GetProduct();
            var mock = new Mock<IApiRequestSend<Product>>();
            var apiControllerMock = new ApiController(mock.Object);

            apiControllerMock.AddProduct(product);
            mock.Verify(m => m.AddEntity(product), Times.Once);
        }

        [Fact]
        public void ApiController_TryModifyEntity_Success()
        {
            var product = GetProduct();
            var mock = new Mock<IApiRequestSend<Product>>();
            var apiControllerMock = new ApiController(mock.Object);

            apiControllerMock.EditProduct(product.Id, product);
            mock.Verify(m => m.ModifyEntity(product.Id, product), Times.Once);
        }


        [Fact]
        public void ApiController_TryDeleteEntity_Success()
        {
            var product = GetProduct();
            var mock = new Mock<IApiRequestSend<Product>>();
            var apiControllerMock = new ApiController(mock.Object);

            apiControllerMock.DeleteProduct(product);
            mock.Verify(m => m.DeleteEntity(product), Times.Once);
        }

        public Product GetProduct()
        {
           return new Product()
            {
                Id = 1,
                Name = "Bicycle",
                Price = 5000,
                Quantity = 10,
                Section = "Section-A"
            };

           
        }

    }
}
