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
    public class OrdersController : ControllerBase
    {
        private readonly DBContext _context;

        public OrdersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders;
        }

        //// GET: api/Orders/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetOrder([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var order = await _context.Orders.FindAsync(id);

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(order);
        //}

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromRoute] int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Order_Idd)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Order_Idd }, order);
        }
        // GET: api/Orders/5/////////////for getting product data 
        [HttpGet("add")]
        public async Task<IActionResult> GetProduct([FromBody] List<int> Id)
        {
            int lastId = 0;int totalItems = 0;float price = 0;float sumTax = 0;int PID = 0;
            lastId=(from order in _context.Orders
             select order.Order_Idd).Max();
            lastId++;
            if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            foreach (int item in Id)
            {
                var product = await _context.Products.FindAsync(item);

                if (product == null)
                {
                    return NotFound();

                }
                totalItems++;
                price += product.Product_Price;
                sumTax += product.Product_Tax;
               
            }
            Order OrderUser = new Order();
            OrderUser.Order_Idd = lastId;
            OrderUser.Order_Status = "Inprogress";
            OrderUser.Total_Items=totalItems;
            OrderUser.Total_Price=price;
            OrderUser.Total_Sum_Tax=sumTax;
            OrderUser.Total_Tax=sumTax;
            await PostOrder(OrderUser);
            return Ok();

        }



        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Order_Idd == id);
        }
    }
}