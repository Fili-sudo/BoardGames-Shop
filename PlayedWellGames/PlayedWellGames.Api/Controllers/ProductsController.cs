using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.Products.Commands;
using PlayedWellGames.Application.Products.Queries;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductPutPostDto product)
        {
            var command = _mapper.Map<ProductPutPostDto, AddProductCommand > (product);

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<Product, ProductGetDto>(created);

            return CreatedAtAction(nameof(GetById), new { productId = created.Id }, dto);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            var query = new GetProductByIdQuery { Id = productId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<Product, ProductGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<Product>, List<ProductGetDto>>(result);
            return Ok(mappedResult);
        }

        [Authorize]
        [Route("{productId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var command = new DeleteProductCommand { Id = productId };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();

        }
        [Authorize]
        [HttpPut]
        [Route("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, ProductPutPostDto updated)
        {
            var product = _mapper.Map<ProductPutPostDto, Product>(updated);
            var command = new UpdateProductCommand { Id = productId, NewProduct = product };

            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();

            return NoContent();
        }

    }
}
