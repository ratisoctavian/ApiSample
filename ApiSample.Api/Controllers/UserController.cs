using ApiSample.BL.Queries;
using ApiSample.Models.DataModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetUserListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
