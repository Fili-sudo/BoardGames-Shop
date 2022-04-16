using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayedWellGames.Api.Dto;
using PlayedWellGames.Application.Users.Querries;
using PlayedWellGames.Core;

namespace PlayedWellGames.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var query = new GetUserByIdQuery { Id = userId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            var mappedResult = _mapper.Map<User, UserGetDto>(result);
            return Ok(mappedResult);
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            var query = new GetUsersQuery();
            var result = await _mediator.Send(query);
            var mappedResult = _mapper.Map<List<User>, List<UserGetDto>>(result);
            return Ok(mappedResult);
        }
    }
}
