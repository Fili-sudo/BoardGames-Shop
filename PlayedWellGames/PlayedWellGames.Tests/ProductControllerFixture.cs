using AutoMapper;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlayedWellGames.Api.Controllers;
using PlayedWellGames.Application.Products.Queries;
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

            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
           
        }
    }
}