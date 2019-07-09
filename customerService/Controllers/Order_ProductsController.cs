using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using customerService;
using customerService.Models;

namespace customerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_ProductsController : ControllerBase
    {
        private readonly DBContext _context;

        public Order_ProductsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Order_Products
        [HttpGet]
        public IEnumerable<Order_Products> GetOrders_Products()
        {
            return _context.Orders_Products;
        }

        // GET: api/Order_Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder_Products([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order_Products = await _context.Orders_Products.FindAsync(id);

            if (order_Products == null)
            {
                return NotFound();
            }

            return Ok(order_Products);
        }

        // PUT: api/Order_Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder_Products([FromRoute] int id, [FromBody] Order_Products order_Products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order_Products.SerialNo)
            {
                return BadRequest();
            }

            _context.Entry(order_Products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Order_Products
        [HttpPost]
        public async Task<IActionResult> PostOrder_Products([FromBody] Order_Products order_Products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders_Products.Add(order_Products);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder_Products", new { id = order_Products.SerialNo }, order_Products);
        }

        // DELETE: api/Order_Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder_Products([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order_Products = await _context.Orders_Products.FindAsync(id);
            if (order_Products == null)
            {
                return NotFound();
            }

            _context.Orders_Products.Remove(order_Products);
            await _context.SaveChangesAsync();

            return Ok(order_Products);
        }

        private bool Order_ProductsExists(int id)
        {
            return _context.Orders_Products.Any(e => e.SerialNo == id);
        }
    }
}