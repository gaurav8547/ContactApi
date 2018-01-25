using ContactApi.Models;
using ContactApi.Repository.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactApi.Controllers
{
    [Route("api/customer/")]
    public class CustomerController : Controller
    {
        ICustomerRepository repo;
        public CustomerController(ICustomerRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = repo.All();

            if(customers == null)
            {
                return NoContent();
            }
            return Ok(repo.All());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {
                repo.Save(customer);
                var x = CreatedAtRoute("GetById", new { id = customer.Id }, customer);
                return x;
            }
            catch (Exception ex)
            {
                return BadRequest("Save Failed");
            }
        }

        [HttpGet("{id}", Name = "GetById")]
        [Route("id")]
        public IActionResult GetById([FromBody] long id)
        {
            var customer = repo.Find(id);
            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
