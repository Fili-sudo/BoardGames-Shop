using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlayedWellGames.Api.Controllers;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.Products.Queries;
using PlayedWellGames.Core;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace PlayedWellGames.Tests
{
    [TestClass]
    public class ProductControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();


        [TestMethod]
        public async Task Get_All_Products_GetAllProductsQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            await controller.Getall();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
           
        }

        [TestMethod]
        public async Task Get_Product_By_Id_GetProductByIdQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetById(1);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());

        }

        [TestMethod]
        public async Task Get_Product_By_Id_GetProductByIdQueryWithCorrectProductIdIsCalled()
        {
            int productId = 0;

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetProductByIdQuery, CancellationToken>(async (q, c) =>
                {
                    productId = q.Id;
                    return await Task.FromResult(
                       new Product
                       {
                           Id = q.Id,
                           ProductName = "A product",
                           Description = "some description",
                           Price = 23,
                           Quantity = 10,
                           Tags = "some tags"
                       });
                    
                });
            _mockMapper.Setup(m => m.Map<Product, ProductGetDto>(It.IsAny<Product>())).Returns(new ProductGetDto());

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);
            
            
            //Assert
            Assert.AreEqual(productId, 1);
            
        }

        [TestMethod]
        public async Task Get_Product_By_Id_ShouldReturnNotFound()
        {

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Product>(null));

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);
            var NotFoundResult = result as NotFoundResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, NotFoundResult.StatusCode);

        }
    }
}