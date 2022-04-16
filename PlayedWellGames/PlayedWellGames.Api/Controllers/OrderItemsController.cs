using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.OrderItems.Queries;
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
    }
}
