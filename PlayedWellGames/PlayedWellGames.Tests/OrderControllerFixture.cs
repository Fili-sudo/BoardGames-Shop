//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MediatR;
//using Moq;
//using AutoMapper;
//using PlayedWellGames.Application.Orders.Queries;
//using System.Threading;
//using PlayedWellGames.Api.Controllers;
//using PlayedWellGames.Core;
//using System.Net;
//using PlayedWellGames.Api.Dto;

//namespace PlayedWellGames.Tests
//{
//    [TestClass]
//    public class OrderControllerFixture
//    {
//        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
//        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

//        [TestMethod]
//        public async Task Get_All_Orders_GetAllOrdersQueryIsCalled()
//        {
//            //Arrange
//            _mockMediator
//                .Setup(m => m.Send(It.IsAny<GetAllOrdersQuery>(), It.IsAny<CancellationToken>()))
//                .Verifiable();

//            //Act
//            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
//            await controller.Getall();

//            //Assert
//            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllOrdersQuery>(), It.IsAny<CancellationToken>()), Times.Once());

//        }

//        [TestMethod]
//        public async Task Get_All_Orders_ShouldReturnOkStatusCode()
//        {
//            //Arrange
//            _mockMediator
//                .Setup(m => m.Send(It.IsAny<GetAllOrdersQuery>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(new List<Order>
//                {
//                    new Order(),
//                    new Order(),
//                    new Order()
//                });

//            //Act
//            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
//            var result = await controller.Getall();
//            var okResult = result as OkObjectResult;


//            //Assert
//            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

//        }

//        [TestMethod]
//        public async Task Get_All_Orders_ResultShouldBeOfTypeListOfOrderGetDto()
//        {
//            //Arrange
//            _mockMediator
//                .Setup(m => m.Send(It.IsAny<GetAllOrdersQuery>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(new List<Order>
//                {
//                    new Order(),
//                    new Order(),
//                    new Order()
//                });
//            _mockMapper
//                .Setup(m => m.Map<List<Order>, List<OrderGetDto>>(It.IsAny<List<Order>>()))
//                .Returns(new List<OrderGetDto>());

//            //Act
//            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
//            var result = await controller.Getall();
//            var okResult = result as OkObjectResult;


//            //Assert
//            Assert.IsInstanceOfType(okResult.Value, typeof(List<OrderGetDto>));

//        }

//        [TestMethod]
//        public async Task Get_Order_By_Id_GetOrderByIdQueryIsCalled()
//        {
//            //Arrange
//            _mockMediator
//                .Setup(m => m.Send(It.IsAny<GetOrderByIdQuery>(), It.IsAny<CancellationToken>()))
//                .Verifiable();

//            //Act
//            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
//            await controller.GetById(1);

//            //Assert
//            _mockMediator.Verify(x => x.Send(It.IsAny<GetOrderByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());

//        }

//        [TestMethod]
//        public async Task Get_Order_By_Id_GetOrderByIdQueryWithCorrectOrderIdIsCalled()
//        {
//            int orderId = 0;

//            //Arrange
//            _mockMediator
//                .Setup(m => m.Send(It.IsAny<GetOrderByIdQuery>(), It.IsAny<CancellationToken>()))
//                .Returns<GetOrderByIdQuery, CancellationToken>(async (q, c) =>
//                {
//                    orderId = q.Id;
//                    return await Task.FromResult(
//                       new Order
//                       {
//                           Id = q.Id,
//                       });

//                });
//            _mockMapper.Setup(m => m.Map<Order, OrderGetDto>(It.IsAny<Order>())).Returns(new OrderGetDto());

//            //Act
//            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
//            var result = await controller.GetById(1);


//            //Assert
//            Assert.AreEqual(orderId, 1);

//        }

//        [TestMethod]
//        public async Task Get_Order_By_Id_ShouldReturnNotFoundStatusCode()
//        {

//            //Arrange
//            _mockMediator
//                .Setup(m => m.Send(It.IsAny<GetOrderByIdQuery>(), It.IsAny<CancellationToken>()))
//                .Returns(Task.FromResult<Order>(null));

//            //Act
//            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
//            var result = await controller.GetById(1);
//            var NotFoundResult = result as NotFoundResult;


//            //Assert
//            Assert.AreEqual((int)HttpStatusCode.NotFound, NotFoundResult.StatusCode);

//        }

//        [TestMethod]
//        public async Task Get_Order_By_Id_ShouldReturnOkStatusCode()
//        {

//            //Arrange
//            _mockMediator
//                .Setup(m => m.Send(It.IsAny<GetOrderByIdQuery>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(new Order
//                {
//                    Id = 1,
//                });

//            //Act
//            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
//            var result = await controller.GetById(1);
//            var okResult = result as OkObjectResult;


//            //Assert
//            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

//        }

//        [TestMethod]
//        public async Task Get_Order_By_Id_ShouldReturnFoundOrder()
//        {
//            //Arrange
//            var order = new Order
//            {
//                Id = 1,
//                ShippingAddress = "some address",
//                State = States.Pending,
//                Price = 30,
//                UserId = 1,
//                OrderItems = new List<OrderItem>
//                {
//                    new OrderItem
//                    {
//                        Id = 1,
//                        OrderId = 1,
//                        ProductId = 1,
//                        Quantity = 2,
//                        Product = new Product
//                        {
//                            Id = 1,
//                            ProductName = "A product",
//                            Description = "some description",
//                            Price = 23,
//                            Quantity = 10,
//                            Tags = "some tags"
//                        }
//                    }
//                }
//            };
//            var orderGetDto = new OrderGetDto
//            {
//                Id = 1,
//                ShippingAddress = "some address",
//                State = States.Pending,
//                Price = 30,
//                UserId = 1,
//                OrderItems = new List<OrderItemGetDto>
//                {
//                    new OrderItemGetDto
//                    {
//                        Id = 1,
//                        ProductId = 1,
//                        Quantity = 2,
//                        Product = new ProductGetDto
//                        {
//                            Id = 1,
//                            ProductName = "A product",
//                            Description = "some description",
//                            Price = 23,
//                            Quantity = 10,
//                            Tags = "some tags"
//                        }
//                    }
//                }

//            };
//            _mockMediator
//                .Setup(m => m.Send(It.IsAny<GetOrderByIdQuery>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(order);
//            _mockMapper
//                .Setup(m => m.Map<Order, OrderGetDto>(It.IsAny<Order>()))
//                .Returns((Order src) => new OrderGetDto()
//                {
//                    Id = src.Id,
//                    ShippingAddress = src.ShippingAddress,
//                    State = src.State,
//                    Price = src.Price,
//                    UserId = (int)src.UserId,
//                    OrderItems = new List<OrderItemGetDto>
//                    {
//                        new OrderItemGetDto
//                        {
//                            Id = src.OrderItems.ToArray()[0].Id,
//                            ProductId = src.OrderItems.ToArray()[0].ProductId,
//                            Quantity = src.OrderItems.ToArray()[0].Quantity,
//                            Product = new ProductGetDto
//                            {
//                                Id = src.OrderItems.ToArray()[0].Product.Id,
//                                Description = src.OrderItems.ToArray()[0].Product.Description,
//                                ProductName = src.OrderItems.ToArray()[0].Product.ProductName,
//                                Price = src.OrderItems.ToArray()[0].Product.Price,
//                                Quantity = src.OrderItems.ToArray()[0].Product.Quantity,
//                                Tags = src.OrderItems.ToArray()[0].Product.Tags
//                            }
//                        }
//                    }
//                });

//            //Act
//            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
//            var result = await controller.GetById(1);

//            var okResult = result as OkObjectResult;

//            //Assert
//            Assert.AreEqual(orderGetDto, okResult.Value);

//        }

//        [TestMethod]
//        public async Task Get_Order_By_Id_ResultShouldBeOfTypeOrderGetDto()
//        {
//            //Arrange
//            var order = new Order
//            {
//                Id = 1,
//                ShippingAddress = "some address",
//                State = States.Pending,
//                Price = 30,
//                UserId = 1,
//                OrderItems = new List<OrderItem>
//                {
//                    new OrderItem
//                    {
//                        Id = 1,
//                        OrderId = 1,
//                        ProductId = 1,
//                        Quantity = 2,
//                        Product = new Product
//                        {
//                            Id = 1,
//                            ProductName = "A product",
//                            Description = "some description",
//                            Price = 23,
//                            Quantity = 10,
//                            Tags = "some tags"
//                        }
//                    }
//                }
//            };
//            _mockMediator
//                .Setup(m => m.Send(It.IsAny<GetOrderByIdQuery>(), It.IsAny<CancellationToken>()))
//                .ReturnsAsync(order);
//            _mockMapper
//                .Setup(m => m.Map<Order, OrderGetDto>(It.IsAny<Order>()))
//                .Returns(new OrderGetDto());

//            //Act
//            var controller = new OrdersController(_mockMediator.Object, _mockMapper.Object);
//            var result = await controller.GetById(1);

//            var okResult = result as OkObjectResult;

//            //Assert
//            Assert.IsInstanceOfType(okResult.Value, typeof(OrderGetDto));

//        }

//    }
//}
