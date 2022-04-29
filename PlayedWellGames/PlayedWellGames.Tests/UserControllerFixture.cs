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
using PlayedWellGames.Application.Users.Queries;
using System.Threading;
using PlayedWellGames.Api.Controllers;
using PlayedWellGames.Core;
using System.Net;
using PlayedWellGames.Api.Dto;

namespace PlayedWellGames.Tests
{
    [TestClass]
    public class UserControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task Get_All_Users_GetAllUsersQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            await controller.Getall();

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>()), Times.Once());

        }
        [TestMethod]
        public async Task Get_All_Users_ShouldReturnOkStatusCode()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<User>
                {
                    new User(),
                    new User(),
                    new User()
                });

            //Act
            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.Getall();
            var okResult = result as OkObjectResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        }

        [TestMethod]
        public async Task Get_All_Users_ResultShouldBeOfTypeListOfUserGetDto()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<User>
                {
                    new User(),
                    new User(),
                    new User()
                });
            _mockMapper
                .Setup(m => m.Map<List<User>, List<UserGetDto>>(It.IsAny<List<User>>()))
                .Returns(new List<UserGetDto>());

            //Act
            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.Getall();
            var okResult = result as OkObjectResult;


            //Assert
            Assert.IsInstanceOfType(okResult.Value, typeof(List<UserGetDto>));

        }
    }
}
