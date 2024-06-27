using Application.DTO.User;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [Authorize]
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

        [HttpGet("GetUserOrders")]
        public IActionResult GetUserOrders(Guid id, [FromServices] UserService userService)
        {
            var orders = userService.GetUserOrders(id);
            return Ok(orders);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] UserService userService)
        {
            var deleted = userService.Delete(id);
            if (!deleted)
                return NotFound();
            return Ok();
        }
    }
}