using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSW2.Models;
using ProjectSW2.Repository;

namespace ProjectSW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Orders = await unitOfWork.OrderTables.GetAllAsync();
            return Ok(Orders);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
                return BadRequest();
            OrderTable order = await unitOfWork.OrderTables.GetByIdAsync(id);
            if (order == null)
                return NotFound("This Order Not Found");
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> MakeOrder([FromBody] OrderTable order)
        {
            if (order == null)
                return BadRequest();
            order.OrderDate = DateTime.Now;
            await unitOfWork.OrderTables.AddAsync(order);
            unitOfWork.Complete();
            return Ok(order.Id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderTable orderupdated)
        {
            OrderTable order = await unitOfWork.OrderTables.GetByIdAsync(id);
            if (order is null)
                return NotFound($"No Order With Id={id}");
            order.IsDelivered = orderupdated.IsDelivered;
            order.UserId = orderupdated.UserId; 
            unitOfWork.OrderTables.Update(order);
            unitOfWork.Complete();
            return Ok(order);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest("No Order With it's Id");
            OrderTable order = await unitOfWork.OrderTables.GetByIdAsync(id);
            if (order == null)
                return NotFound("Not found this order");
            unitOfWork.OrderTables.Delete(order);
            unitOfWork.Complete();
            return Ok(order.Id);
        }
    }
}
