using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.OrderItems.Queries;
using PlayedWellGames.Application.Orders.Queries;
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
    }
}
