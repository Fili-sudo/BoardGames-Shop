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

    }
}
