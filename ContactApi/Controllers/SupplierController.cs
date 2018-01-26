using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApi.Models;
using ContactApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Supplier")]
    public class SupplierController : Controller
    {
        ISupplierRepository repo;
        public SupplierController(ISupplierRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var suppliers = await repo.All();

            if (suppliers == null)
            {
                return NoContent();
            }
            return Ok(suppliers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Supplier supplier)
        {
            try
            {
                await repo.Save(supplier);
                return CreatedAtRoute("GetById", new { id = supplier.Id }, supplier);
            }
            catch (Exception ex)
            {
                return BadRequest("Save Failed" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Supplier supplier)
        {
            try
            {
                await repo.Save(supplier); ;
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
            var supplier = await repo.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
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