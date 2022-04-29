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

        [TestMethod]
        public async Task Get_User_By_Id_GetUserByIdQueryIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetById(1);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());

        }

        [TestMethod]
        public async Task Get_User_By_Id_GetUserByIdQueryWithCorrectUserIdIsCalled()
        {
            int userId = 0;

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetUserByIdQuery, CancellationToken>(async (q, c) =>
                {
                    userId = q.Id;
                    return await Task.FromResult(
                       new User
                       {
                           Id = q.Id,
                           FirstName = "John",
                           LastName = "Davis",
                           Mail = "john.davis@gmail.com",
                           UserName = "john.davis",
                           Pass = "1234",
                           Phone = "0771671642",
                           Address = "some address",
                           Role = Role.Regular
                       });

                });
            _mockMapper.Setup(m => m.Map<User, UserGetDto>(It.IsAny<User>())).Returns(new UserGetDto());

            //Act
            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);


            //Assert
            Assert.AreEqual(userId, 1);

        }

        [TestMethod]
        public async Task Get_User_By_Id_ShouldReturnNotFoundStatusCode()
        {

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<User>(null));

            //Act
            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);
            var NotFoundResult = result as NotFoundResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, NotFoundResult.StatusCode);

        }

        [TestMethod]
        public async Task Get_User_By_Id_ShouldReturnOkStatusCode()
        {

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Davis",
                    Mail = "john.davis@gmail.com",
                    UserName = "john.davis",
                    Pass = "1234",
                    Phone = "0771671642",
                    Address = "some address",
                    Role = Role.Regular
                });

            //Act
            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);
            var okResult = result as OkObjectResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        }

        [TestMethod]
        public async Task Get_User_By_Id_ShouldReturnFoundUser()
        {
            //Arrange
            var user = new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Davis",
                Mail = "john.davis@gmail.com",
                UserName = "john.davis",
                Pass = "1234",
                Phone = "0771671642",
                Address = "some address",
                Role = Role.Regular
            };
            var userGetDto = new UserGetDto
            {
                Id = 1,
                FirstName = "John",
                LastName = "Davis",
                Mail = "john.davis@gmail.com",
                UserName = "john.davis",
                Phone = "0771671642",
                Address = "some address",
                Role = Role.Regular
            };
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);
            _mockMapper
                .Setup(m => m.Map<User, UserGetDto>(It.IsAny<User>()))
                .Returns((User src) => new UserGetDto()
                {
                    Id = src.Id,
                    FirstName = src.FirstName,
                    LastName = src.LastName,
                    Mail = src.Mail,
                    UserName = src.UserName,
                    Phone = src.Phone,
                    Address = src.Address,
                    Role = src.Role
                });

            //Act
            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            //Assert
            Assert.AreEqual(userGetDto, okResult.Value);

        }

        [TestMethod]
        public async Task Get_Product_By_Id_ResultShouldBeOfTypeProductGetDto()
        {
            //Arrange
            var user = new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Davis",
                Mail = "john.davis@gmail.com",
                UserName = "john.davis",
                Pass = "1234",
                Phone = "0771671642",
                Address = "some address",
                Role = Role.Regular
            };
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(user);
            _mockMapper
                .Setup(m => m.Map<User, UserGetDto>(It.IsAny<User>()))
                .Returns(new UserGetDto());

            //Act
            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            //Assert
            Assert.IsInstanceOfType(okResult.Value, typeof(UserGetDto));

        }
    }
}
