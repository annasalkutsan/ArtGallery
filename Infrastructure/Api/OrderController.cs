using Application.DTO.Order.Pag;
using Application.DTO.User;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] OrderCreateRequest orderCreateRequest, [FromServices] OrderService orderService)
        {
            try
            {
                var createdOrder = await orderService.CreateAsync(orderCreateRequest);
                return Ok(createdOrder);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] OrderUpdateRequest orderUpdateRequest, [FromServices] OrderService orderService)
        {
            var updatedOrder = await orderService.Update(orderUpdateRequest);
            if (updatedOrder == null)
                return NotFound();
            return Ok(updatedOrder);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices][FromQuery] OrderService orderService)
        {
            var orders = orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid id, [FromServices] OrderService orderService)
        {
            var order = orderService.GetById(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpGet("GetOrdersNotStarted")]
        public IActionResult GetOrdersNotStarted([FromServices] OrderService orderService)
        {
            var orders = orderService.GetOrdersNotStarted();
            return Ok(orders);
        }

        [HttpGet("GetOrdersReady")]
        public IActionResult GetOrdersReady([FromServices] OrderService orderService)
        {
            var orders = orderService.GetOrdersReady();
            return Ok(orders);
        }

        [HttpGet("GetOrdersInDevelopment")]
        public IActionResult GetOrdersInDevelopment([FromServices] OrderService orderService)
        {
            var orders = orderService.GetOrdersInDevelopment();
            return Ok(orders);
        }

        [HttpGet("GetPagedOrders")]
        public IActionResult GetPagedOrders([FromBody] OrderListRequest request, [FromServices] OrderService orderService)
        {
            var pagedOrders = orderService.GetPagedOrders(request);
            return Ok(pagedOrders);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] OrderService orderService)
        {
            var deleted = orderService.Delete(id);
            if (!deleted)
                return NotFound();
            return Ok();
        }
    }
}