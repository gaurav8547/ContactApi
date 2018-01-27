using ContactApi.Models;
using ContactApi.Repository.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ContactApi.Controllers
{
    [Produces("application/json")]
    [Route("api/customer/")]
    public class CustomerController : Controller
    {
        ICustomerRepository repo;
        public CustomerController(ICustomerRepository customerRepo)
        {
            repo = customerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()      
        {
            var customers = await repo.All();

            if(customers == null)
            {
                return NoContent();
            }
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            try
            {
                await repo.Save(customer);
                return CreatedAtRoute("GetById", new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {
                return BadRequest("Save Failed" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Customer customer)
        {
            try
            {
                await repo.Save(customer);;
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Update Failed" + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetById")]        
        public async Task<IActionResult> Get(long id)
        {
            var customer = await repo.Find(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpDelete]
        public IActionResult Remove(long id)
        {
            try
            {
                repo.Remove(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
