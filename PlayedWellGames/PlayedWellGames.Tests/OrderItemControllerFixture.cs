using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Moq;
using PlayedWellGames.Application.OrderItems.Queries;
using System.Threading;
using PlayedWellGames.Api.Controllers;
using PlayedWellGames.Core;
using System.Net;
using PlayedWellGames.Api.Dto;

namespace PlayedWellGames.Tests
{
    [TestClass]
    public class OrderItemControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_OrderItems_GetAllOrderItemsQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllOrderItemsQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new OrderItemsController(_mockMediator.Object, _mockMapper.Object);
            await controller.Getall();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllOrderItemsQuery>(), It.IsAny<CancellationToken>()), Times.Once());

        }

        [TestMethod]
        public async Task Get_All_OrderItems_ShouldReturnOkStatusCode()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllOrderItemsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<OrderItem>
                {
                    new OrderItem(),
                    new OrderItem(),
                    new OrderItem()
                });

            //Act
            var controller = new OrderItemsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.Getall();
            var okResult = result as OkObjectResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        }

        [TestMethod]
        public async Task Get_All_OrderItems_ResultShouldBeOfTypeListOfOrderItemsGetDto()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllOrderItemsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<OrderItem>
                {
                    new OrderItem(),
                    new OrderItem(),
                    new OrderItem()
                });
            _mockMapper
                .Setup(m => m.Map<List<OrderItem>, List<OrderItemGetDto>>(It.IsAny<List<OrderItem>>()))
                .Returns(new List<OrderItemGetDto>());

            //Act
            var controller = new OrderItemsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.Getall();
            var okResult = result as OkObjectResult;


            //Assert
            Assert.IsInstanceOfType(okResult.Value, typeof(List<OrderItemGetDto>));

        }

        [TestMethod]
        public async Task Get_OrderItem_By_Id_GetOrderItemByIdQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetOrderItemByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new OrderItemsController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetById(1);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetOrderItemByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());

        }

        [TestMethod]
        public async Task Get_OrderItem_By_Id_GetOrderItemByIdQueryWithCorrectOrderItemIdIsCalled()
        {
            int orderItemId = 0;

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetOrderItemByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetOrderItemByIdQuery, CancellationToken>(async (q, c) =>
                {
                    orderItemId = q.Id;
                    return await Task.FromResult(
                       new OrderItem
                       {
                           Id = q.Id,
                       });

                });
            _mockMapper.Setup(m => m.Map<OrderItem, OrderItemGetDto>(It.IsAny<OrderItem>())).Returns(new OrderItemGetDto());

            //Act
            var controller = new OrderItemsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);


            //Assert
            Assert.AreEqual(orderItemId, 1);

        }

        [TestMethod]
        public async Task Get_OrderItem_By_Id_ShouldReturnNotFoundStatusCode()
        {

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetOrderItemByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<OrderItem>(null));

            //Act
            var controller = new OrderItemsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);
            var NotFoundResult = result as NotFoundResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, NotFoundResult.StatusCode);

        }

        [TestMethod]
        public async Task Get_OrderItem_By_Id_ShouldReturnOkStatusCode()
        {

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetOrderItemByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new OrderItem
                {
                    Id = 1,
                });

            //Act
            var controller = new OrderItemsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);
            var okResult = result as OkObjectResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        }

        [TestMethod]
        public async Task Get_OrderItem_By_Id_ShouldReturnFoundOrderItem()
        {
            //Arrange
            var orderItem = new OrderItem
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1,
                Quantity = 2,
                Product = new Product
                {
                    Id = 1,
                    ProductName = "A product",
                    Description = "some description",
                    Price = 23,
                    Quantity = 10,
                    Tags = "some tags"
                }
            };
            var orderItemGetDto = new OrderItemGetDto
            {
                Id = 1,
                ProductId = 1,
                Quantity = 2,
                Product = new ProductGetDto
                {
                    Id = 1,
                    ProductName = "A product",
                    Description = "some description",
                    Price = 23,
                    Quantity = 10,
                    Tags = "some tags"
                }
            };
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetOrderItemByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(orderItem);
            _mockMapper
                .Setup(m => m.Map<OrderItem, OrderItemGetDto>(It.IsAny<OrderItem>()))
                .Returns((OrderItem src) => new OrderItemGetDto()
                {
                    Id = src.Id,
                    ProductId = src.ProductId,
                    Quantity = src.Quantity,
                    Product = new ProductGetDto
                    {
                        Id = src.Product.Id,
                        Description = src.Product.Description,
                        ProductName = src.Product.ProductName,
                        Price = src.Product.Price,
                        Quantity = src.Product.Quantity,
                        Tags = src.Product.Tags
                    }
                });

            //Act
            var controller = new OrderItemsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            //Assert
            Assert.AreEqual(orderItemGetDto, okResult.Value);

        }

        [TestMethod]
        public async Task Get_OrderItem_By_Id_ResultShouldBeOfTypeOrderItemGetDto()
        {
            //Arrange
            var orderItem = new OrderItem
            {
                Id = 1,
                OrderId = 1,
                ProductId = 1,
                Quantity = 2,
                Product = new Product
                {
                    Id = 1,
                    ProductName = "A product",
                    Description = "some description",
                    Price = 23,
                    Quantity = 10,
                    Tags = "some tags"
                }
            };
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetOrderItemByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(orderItem);
            _mockMapper
                .Setup(m => m.Map<OrderItem, OrderItemGetDto>(It.IsAny<OrderItem>()))
                .Returns(new OrderItemGetDto());

            //Act
            var controller = new OrderItemsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            //Assert
            Assert.IsInstanceOfType(okResult.Value, typeof(OrderItemGetDto));

        }

    }
}
