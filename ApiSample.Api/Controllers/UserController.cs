using ApiSample.BL.Commands;
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
        [Route("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetUserListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var command = new CreateUserCommand(user.FirstName, user.LastName, user.LoginName, user.Email, user.PhoneNumber, user.UserTypes);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var command = new UpdateUserCommand(user.FirstName, user.LastName, user.LoginName, user.Email, user.PhoneNumber, user.UserTypes);

            var result = await _mediator.Send(command);

            return result != null ?  Ok(result) : NotFound();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteUser([FromBody] string loginName)
        {       
            var command = new DeleteUserCommand(loginName);

            var result = await _mediator.Send(command);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
