using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Moq;
using AutoMapper;
using PlayedWellGames.Application.Orders.Queries;
using System.Threading;
using PlayedWellGames.Api.Controllers;
using PlayedWellGames.Core;
using System.Net;
using PlayedWellGames.Api.Dto;

namespace PlayedWellGames.Tests
{
    [TestClass]
    public class OrderControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Orders_GetAllOrdersQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllOrdersQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
            await controller.Getall();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllOrdersQuery>(), It.IsAny<CancellationToken>()), Times.Once());

        }

        [TestMethod]
        public async Task Get_All_Orders_ShouldReturnOkStatusCode()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllOrdersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Order>
                {
                    new Order(),
                    new Order(),
                    new Order()
                });

            //Act
            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.Getall();
            var okResult = result as OkObjectResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        }

        [TestMethod]
        public async Task Get_All_Orders_ResultShouldBeOfTypeListOfOrderGetDto()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllOrdersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Order>
                {
                    new Order(),
                    new Order(),
                    new Order()
                });
            _mockMapper
                .Setup(m => m.Map<List<Order>, List<OrderGetDto>>(It.IsAny<List<Order>>()))
                .Returns(new List<OrderGetDto>());

            //Act
            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.Getall();
            var okResult = result as OkObjectResult;


            //Assert
            Assert.IsInstanceOfType(okResult.Value, typeof(List<OrderGetDto>));

        }

    }
}
