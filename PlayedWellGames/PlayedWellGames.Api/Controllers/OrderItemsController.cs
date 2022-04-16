using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.OrderItems.Commands;
using PlayedWellGames.Application.OrderItems.Queries;
using PlayedWellGames.Application.Products.Queries;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderItemsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{orderItemId}")]
        public async Task<IActionResult> GetById(int orderItemId)
        {
            var query = new GetOrderItemByIdQuery { Id = orderItemId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<OrderItem, OrderItemGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var query = new GetAllOrderItemsQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<OrderItem>, List<OrderItemGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(OrderItemPostDto orderItem)
        {
            var theOrderItem = _mapper.Map<OrderItemPostDto, OrderItem>(orderItem);

            var product = await _mediator.Send(new GetProductByIdQuery { Id = theOrderItem.ProductId });
            if (product == null)
            {
                return BadRequest();
            }
            theOrderItem.Product = product;

            var command = _mapper.Map<OrderItem, AddOrderItemCommand>(theOrderItem);

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<OrderItem, OrderItemGetDto>(created);

            return CreatedAtAction(nameof(GetById), new { OrderItemId = created.Id }, dto);
        }

        [Route("{orderItemId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderItem(int orderItemId)
        {
            var command = new DeleteOrderItemCommand { Id = orderItemId };
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return NoContent();

        }

        [HttpPut]
        [Route("{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItem(int orderItemId, [FromBody] OrderItemPutDto newOrderItem)
        {
            var command = new UpdateOrderItemQuantityCommand { Id = orderItemId, newQuantity = newOrderItem.Quantity };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();
            
            return NoContent();

        }
    }
}
