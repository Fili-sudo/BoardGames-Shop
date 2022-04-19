using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.OrderItems.Queries;
using PlayedWellGames.Application.Orders.Commands;
using PlayedWellGames.Application.Orders.Queries;
using PlayedWellGames.Application.Users.Querries;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetById(int orderId)
        {
            var query = new GetOrderByIdQuery { Id = orderId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<Order, OrderGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<Order>, List<OrderGetDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderPostDto order)
        {

            var command = _mapper.Map<OrderPostDto, AddOrderCommand>(order);
            if (order.UserId != null)
            {
                var user = await _mediator.Send(new GetUserByIdQuery { Id = (int)order.UserId });
                if(user == null)
                {
                    return BadRequest();
                }
                command.User = user;
                command.ShippingAddress = user.Address;
            }
            else
            {
                command.ShippingAddress = "";
            }

            var created = await _mediator.Send(command);
            var dto = _mapper.Map<Order, OrderGetDto>(created);

            return CreatedAtAction(nameof(GetById), new { orderId = created.Id }, dto);
        }

        [HttpPatch]
        [Route("{orderId}/orderItems/{orderItemId}")]
        public async Task<IActionResult> AddOrderItemToOrder(int orderId, int orderItemId)
        {
            var command = new AddOrderItemToOrderCommand
            {
                OrderId = orderId,
                OrderItemId = orderItemId
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest();
            }
            return NoContent();
            
        }

        [HttpDelete]
        [Route("{orderId}/orderItems/{orderItemId}")]
        public async Task<IActionResult> RemoveOrderItemFromOrder(int orderId, int orderItemId)
        {
            var command = new DeleteOrderItemFromOrderCommand
            {
                OrderId = orderId,
                OrderItemId = orderItemId
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        
        }

        [HttpPut]
        [Route("{orderId}/orderItems/{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItemFromOrder(int orderId, int orderItemId, OrderItemPutDto orderItem)
        {
            var command = new UpdateOrderItemFromOrderCommand
            {
                OrderId = orderId,
                OrderItemId = orderItemId,
                NewQuantity = orderItem.Quantity
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest();
            }
            return NoContent();

        }
    }
}
