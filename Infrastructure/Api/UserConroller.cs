using Application.DTO.User;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] UserService userService)
        {
            var users = userService.GetAll();
            return Ok(users);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid id, [FromServices] UserService userService)
        {
            var user = userService.GetById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] UserCreateRequest userCreateRequest, [FromServices] UserService userService)
        {
            try
            {
                var createdUser = await userService.Registration(userCreateRequest);
                return Ok(createdUser);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Login")]
        public IActionResult Login(UserLoginRequest loginRequest, [FromServices] UserService userService)
        {
            try
            {
                var user = userService.Login(loginRequest);
                return Ok(user);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest userUpdateRequest, [FromServices] UserService userService)
        {
            try
            {
                var updatedUser = await userService.Update(userUpdateRequest);
                return Ok(updatedUser);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] UserService userService)
        {
            var deleted = userService.Delete(id);
            if (!deleted)
                return NotFound();
            return Ok();
        }

        [HttpGet("GetUserOrders")]
        public IActionResult GetUserOrders(Guid id, [FromServices] UserService userService)
        {
            var orders = userService.GetUserOrders(id);
            return Ok(orders);
        }
    }