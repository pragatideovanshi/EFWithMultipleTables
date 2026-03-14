using EF_Multiple_Tables.Models;
using EFMultipleTables.Data;
using EFMultipleTables.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFMultipleTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            try
            {
                var result = await _context.Orders
                    .Include(o => o.Customer)
                    .ToListAsync();
                foreach(var r in result)
                {
                    Customer s = r.Customer;
                    string s2 = s.Name;
                }
                return result;
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto dto)
        {
            var order = new Order
            {
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                CustomersId = dto.C_Id
            };
            _context.Orders.Add(order);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }

            return Ok(order);
        }
    }
}