using ApiSample.BL.Commands;
using ApiSample.BL.Commands.Users;
using ApiSample.BL.Queries;
using ApiSample.BL.Queries.Users;
using ApiSample.Models.DataModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Api.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
             _logger= logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        [ApiExplorerSettings(GroupName = "1.0")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetUserListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll")]
        [ApiExplorerSettings(GroupName = "2.0")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetAllUsersV2()
        {
            var query = new GetUserListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUser")]
        [ApiExplorerSettings(GroupName = "1.0")]
        [MapToApiVersion("1.0")]

        public async Task<IActionResult> GetUser([FromQuery] string loginName)
        {
            var query = new GetUserByLoginNameQuery(loginName);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("GetUser")]
        [ApiExplorerSettings(GroupName = "2.0")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetUserV2([FromQuery] string loginName)
        {
            var query = new GetUserByLoginNameQuery(loginName);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        [Route("Create")]
        [ApiExplorerSettings(GroupName = "1.0")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var command = new CreateUserCommand(user.FirstName, user.LastName, user.LoginName, user.Email, user.PhoneNumber, user.UserType);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("Update")]
        [ApiExplorerSettings(GroupName = "1.0")]

        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var command = new UpdateUserCommand(user.FirstName, user.LastName, user.LoginName, user.Email, user.PhoneNumber, user.UserType);

            var result = await _mediator.Send(command);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("Delete")]
        [ApiExplorerSettings(GroupName = "1.0")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteUser([FromBody] string loginName)
        {
            var command = new DeleteUserCommand(loginName);

            var result = await _mediator.Send(command);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
