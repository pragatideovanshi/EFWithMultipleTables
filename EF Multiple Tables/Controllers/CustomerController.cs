using EF_Multiple_Tables.Models;
using EFMultipleTables.Data;
using EFMultipleTables.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFMultipleTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var result= await _context.Customers
                .Include(c => c.Orders)
                .ToListAsync();
            foreach (var r in result)
            {
                foreach(var r2 in r.Orders)
                {

                }
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDto dto)
        {
            var customer = new Customer
            {
                Name = dto.Name,
                Email = dto.Email
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }
    }
}