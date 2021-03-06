using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlayedWellGames.Api.Controllers;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.Products.Commands;
using PlayedWellGames.Application.Products.Queries;
using PlayedWellGames.Core;
using System;
using System.Collections.Generic;
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
        public async Task Get_All_Products_ShouldReturnOkStatusCode()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Product>
                {
                    new Product(),
                    new Product(),
                    new Product()
                });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.Getall();
            var okResult = result as OkObjectResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        }

        [TestMethod]
        public async Task Get_All_Products_ResultShouldBeOfTypeListOfProductGetDto()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Product>
                {
                    new Product(),
                    new Product(),
                    new Product()
                });
            _mockMapper
                .Setup(m => m.Map<List<Product>, List<ProductGetDto>>(It.IsAny<List<Product>>()))
                .Returns(new List<ProductGetDto>());

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.Getall();
            var okResult = result as OkObjectResult;


            //Assert
            Assert.IsInstanceOfType(okResult.Value, typeof(List<ProductGetDto>));

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
        public async Task Get_Product_By_Id_ShouldReturnNotFoundStatusCode()
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

        [TestMethod]
        public async Task Get_Product_By_Id_ShouldReturnOkStatusCode()
        {

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Product
                {
                    Id = 1,
                    ProductName = "A product",
                    Description = "some description",
                    Price = 23,
                    Quantity = 10,
                    Tags = "some tags"
                });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);
            var okResult = result as OkObjectResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);

        }

        [TestMethod]
        public async Task Get_Product_By_Id_ShouldReturnFoundProduct()
        {
            //Arrange
            var product = new Product
            {
                Id = 1,
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };
            var productGetDto = new ProductGetDto
            {
                Id = 1,
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(product);
            _mockMapper
                .Setup(m => m.Map<Product, ProductGetDto>(It.IsAny<Product>()))
                .Returns((Product src) => new ProductGetDto() 
                { 
                    Id = src.Id,
                    ProductName = src.ProductName,
                    Description = src.Description,
                    Price = src.Price,
                    Quantity = src.Quantity,
                    Tags = src.Tags
                });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            //Assert
            Assert.AreEqual(productGetDto, okResult.Value);

        }

        [TestMethod]
        public async Task Get_Product_By_Id_ResultShouldBeOfTypeProductGetDto()
        {
            //Arrange
            var product = new Product
            {
                Id = 1,
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(product);
            _mockMapper
                .Setup(m => m.Map<Product, ProductGetDto>(It.IsAny<Product>()))
                .Returns(new ProductGetDto());

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.GetById(1);

            var okResult = result as OkObjectResult;

            //Assert
            Assert.IsInstanceOfType(okResult.Value, typeof(ProductGetDto));

        }

        [TestMethod]
        public async Task Delete_Product_DeleteProductCommandIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            await controller.DeleteProduct(1);

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()), Times.Once());

        }

        [TestMethod]
        public async Task Delete_Product_ShouldReturnNotFoundStatusCode()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Product>(null));

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.DeleteProduct(1);
            var NotFoundResult = result as NotFoundResult;

            //Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, NotFoundResult.StatusCode);

        }

        [TestMethod]
        public async Task Delete_Product_DeleteProductCommandWithCorrectProductIdIsCalled()
        {
            int productId = 0;

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns<DeleteProductCommand, CancellationToken>(async (q, c) =>
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

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.DeleteProduct(1);


            //Assert
            Assert.AreEqual(productId, 1);

        }

        [TestMethod]
        public async Task Delete_Product_ShouldReturnNoContentStatusCode()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Product
                {
                    Id = 1,
                    ProductName = "A product",
                    Description = "some description",
                    Price = 23,
                    Quantity = 10,
                    Tags = "some tags"
                });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.DeleteProduct(1);
            var NoContentResult = result as NoContentResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.NoContent, NoContentResult.StatusCode);

        }

        [TestMethod]
        public async Task Update_Product_UpdateProductCommandIsCalled()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            await controller.UpdateProduct(1, new ProductPutPostDto());

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()), Times.Once());

        }

        [TestMethod]
        public async Task Update_Product_UpdateProductCommandWithCorrectProductIdIsCalled()
        {
            int productId = 0;

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns<UpdateProductCommand, CancellationToken>(async (q, c) =>
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

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.UpdateProduct(1, new ProductPutPostDto());


            //Assert
            Assert.AreEqual(productId, 1);

        }

        [TestMethod]
        public async Task Update_Product_UpdateProductCommandWithCorrectProductIsCalled()
        {
            //Arrange
            var testProduct = new Product();

            var productPutPostDto = new ProductPutPostDto
            {
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };
            var product = new Product
            {
                Id = 1,
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };

            _mockMapper
               .Setup(m => m.Map<ProductPutPostDto, Product>(It.IsAny<ProductPutPostDto>()))
               .Returns((ProductPutPostDto src) => new Product()
               {
                   Id = 1,
                   ProductName = src.ProductName,
                   Description = src.Description,
                   Price = src.Price,
                   Quantity = src.Quantity,
                   Tags = src.Tags
               });
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns<UpdateProductCommand, CancellationToken>(async (q, c) =>
                {
                    testProduct = q.NewProduct;
                    return await Task.FromResult(
                       new Product
                       {
                           Id = 1,
                           ProductName = "A product",
                           Description = "some description",
                           Price = 23,
                           Quantity = 10,
                           Tags = "some tags"
                       });

                });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.UpdateProduct(1, productPutPostDto);


            //Assert
            Assert.AreEqual(testProduct.Id, product.Id);
            Assert.AreEqual(testProduct.ProductName, product.ProductName);
            Assert.AreEqual(testProduct.Description, product.Description);
            Assert.AreEqual(testProduct.Price, product.Price);
            Assert.AreEqual(testProduct.Quantity, product.Quantity);
            Assert.AreEqual(testProduct.Tags, product.Tags);

        }

        [TestMethod]
        public async Task Update_Product_ShouldReturnNotFoundStatusCode()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Product>(null));

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.UpdateProduct(1, new ProductPutPostDto());
            var NotFoundResult = result as NotFoundResult;

            //Assert
            Assert.AreEqual((int)HttpStatusCode.NotFound, NotFoundResult.StatusCode);

        }

        [TestMethod]
        public async Task Update_Product_ShouldReturnNoContentStatusCode()
        {

            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Product
                {
                    Id = 1,
                    ProductName = "A product",
                    Description = "some description",
                    Price = 23,
                    Quantity = 10,
                    Tags = "some tags"
                });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.UpdateProduct(1, new ProductPutPostDto());
            var NoContentResult = result as NoContentResult;


            //Assert
            Assert.AreEqual((int)HttpStatusCode.NoContent, NoContentResult.StatusCode);

        }

        [TestMethod]
        public async Task Create_Product_CreateProductCommandIsCalled()
        {
            //Arrange
            var product = new Product
            {
                Id = 1,
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(product)
                .Verifiable();

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.CreateProduct( new ProductPutPostDto());

            //Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()), Times.Once());

        }

        [TestMethod]
        public async Task Create_Product_CreateProductWithCorrectProductIsCalled()
        {
            //Arrange
            var testProduct = new Product();

            var product = new Product()
            {
                Id = 1,
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };

            var productPostPutDto = new ProductPutPostDto
            {
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns<AddProductCommand, CancellationToken>(async (q, c) =>
                {
                    testProduct.Id = q.Id;
                    testProduct.ProductName = q.ProductName;
                    testProduct.Description = q.Description;
                    testProduct.Price = q.Price;
                    testProduct.Quantity = q.Quantity;
                    testProduct.Tags = q.Tags;

                    return await Task.FromResult(
                       new Product
                       {
                           Id = 1,
                           ProductName = "A product",
                           Description = "some description",
                           Price = 23,
                           Quantity = 10,
                           Tags = "some tags"
                       });

                });
            _mockMapper
               .Setup(m => m.Map<ProductPutPostDto, AddProductCommand>(It.IsAny<ProductPutPostDto>()))
               .Returns((ProductPutPostDto src) => new AddProductCommand()
               {
                   Id = 1,
                   ProductName = src.ProductName,
                   Description = src.Description,
                   Price = src.Price,
                   Quantity = src.Quantity,
                   Tags = src.Tags
               });
            _mockMapper
               .Setup(m => m.Map<Product, ProductGetDto>(It.IsAny<Product>()))
               .Returns((Product src) => new ProductGetDto()
               {
                   Id = src.Id,
                   ProductName = src.ProductName,
                   Description = src.Description,
                   Price = src.Price,
                   Quantity = src.Quantity,
                   Tags = src.Tags
               });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.CreateProduct(productPostPutDto);

            //Assert
            Assert.AreEqual(testProduct.Id, product.Id);
            Assert.AreEqual(testProduct.ProductName, product.ProductName);
            Assert.AreEqual(testProduct.Description, product.Description);
            Assert.AreEqual(testProduct.Price, product.Price);
            Assert.AreEqual(testProduct.Quantity, product.Quantity);
            Assert.AreEqual(testProduct.Tags, product.Tags);

        }

        [TestMethod]
        public async Task Create_Product_ShouldReturnCreatedAtActionStatusCode()
        {
            //Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns<AddProductCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                       new Product
                       {
                           Id = 1,
                           ProductName = "A product",
                           Description = "some description",
                           Price = 23,
                           Quantity = 10,
                           Tags = "some tags"
                       });

                });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.CreateProduct(new ProductPutPostDto());
            var createdAtActionResult = result as CreatedAtActionResult;

            //Assert
            Assert.AreEqual((int)HttpStatusCode.Created, createdAtActionResult.StatusCode);

        }

        [TestMethod]
        public async Task Create_Product_ShouldReturnCreatedProductAsProductGetDto()
        {
            //Arrange
            var productPostPutDto = new ProductPutPostDto
            {
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };
            var productGetDto = new ProductGetDto
            {
                Id = 1,
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns<AddProductCommand, CancellationToken>(async (q, c) =>
                {
                    return await Task.FromResult(
                       new Product
                       {
                           Id = 1,
                           ProductName = "A product",
                           Description = "some description",
                           Price = 23,
                           Quantity = 10,
                           Tags = "some tags"
                       });

                });
            _mockMapper
               .Setup(m => m.Map<ProductPutPostDto, AddProductCommand>(It.IsAny<ProductPutPostDto>()))
               .Returns((ProductPutPostDto src) => new AddProductCommand()
               {
                   Id = 1,
                   ProductName = src.ProductName,
                   Description = src.Description,
                   Price = src.Price,
                   Quantity = src.Quantity,
                   Tags = src.Tags
               });
            _mockMapper
               .Setup(m => m.Map<Product, ProductGetDto>(It.IsAny<Product>()))
               .Returns((Product src) => new ProductGetDto()
               {
                   Id = src.Id,
                   ProductName = src.ProductName,
                   Description = src.Description,
                   Price = src.Price,
                   Quantity = src.Quantity,
                   Tags = src.Tags
               });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.CreateProduct(productPostPutDto);
            var createdAtActionResult = result as CreatedAtActionResult;

            //Assert
            Assert.AreEqual(productGetDto, createdAtActionResult.Value);

        }

        [TestMethod]
        public async Task Create_Product_ActionNameShouldBeGetById()
        {
            //Arrange
            var product = new Product
            {
                Id = 1,
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(product);
            

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.CreateProduct(new ProductPutPostDto());
            var createdAtActionResult = result as CreatedAtActionResult;

            //Assert
            Assert.AreEqual(nameof(controller.GetById), createdAtActionResult.ActionName);

        }

        [TestMethod]
        public async Task Create_Product_RouteValueShouldBeTheValueofId()
        {
            //Arrange
            int productId = 0;

            var productPostPutDto = new ProductPutPostDto
            {
                ProductName = "A product",
                Description = "some description",
                Price = 23,
                Quantity = 10,
                Tags = "some tags"
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns<AddProductCommand, CancellationToken>(async (q, c) =>
                {
                    productId = q.Id;
                    return await Task.FromResult(
                       new Product
                       {
                           Id = 1,
                           ProductName = "A product",
                           Description = "some description",
                           Price = 23,
                           Quantity = 10,
                           Tags = "some tags"
                       });

                });
            _mockMapper
               .Setup(m => m.Map<ProductPutPostDto, AddProductCommand>(It.IsAny<ProductPutPostDto>()))
               .Returns((ProductPutPostDto src) => new AddProductCommand()
               {
                   Id = 1,
                   ProductName = src.ProductName,
                   Description = src.Description,
                   Price = src.Price,
                   Quantity = src.Quantity,
                   Tags = src.Tags
               });
            _mockMapper
               .Setup(m => m.Map<Product, ProductGetDto>(It.IsAny<Product>()))
               .Returns((Product src) => new ProductGetDto()
               {
                   Id = src.Id,
                   ProductName = src.ProductName,
                   Description = src.Description,
                   Price = src.Price,
                   Quantity = src.Quantity,
                   Tags = src.Tags
               });

            //Act
            var controller = new ProductsController(_mockMediator.Object, _mockMapper.Object);
            var result = await controller.CreateProduct(productPostPutDto);
            var createdAtActionResult = result as CreatedAtActionResult;

            //Assert
            Assert.AreEqual(productId, (int)createdAtActionResult.RouteValues.GetValueOrDefault("productId"));

        }
    }
} 