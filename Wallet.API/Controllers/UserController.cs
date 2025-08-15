using Microsoft.AspNetCore.Mvc;
using Wallet.API.Contracts;
using Wallet.Core.Abstract;

namespace Wallet.API.Controllers
{
    [ApiController]
    [Route("[userController]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetUser(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();
            var user = await _userService.Get(id);
            var response = new UserResponse(user.Id,user.Name, user.Email, user.Password);

            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UserRequest request)
        {
            var (user, error) = Core.Models.User.CreateUser(request.Name, request.Email, request.Password, new());
            if(!string.IsNullOrEmpty(error))
                return BadRequest(error);

            var userId = await _userService.Create(user);

            return Ok(userId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] UserRequest request)
        {
            var userId = await _userService.Update(id, request.Name, request.Email, request.Password);
            return Ok(userId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid userId)
        {
            var deletedUserId = await _userService.Delete(userId);
            return Ok(deletedUserId);
        }
    }
}
