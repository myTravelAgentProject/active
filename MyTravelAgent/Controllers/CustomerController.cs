using BL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTravelAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerBL customerBL;
        public CustomerController(ICustomerBL customerBL)
        {
            this.customerBL = customerBL;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await customerBL.getAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await customerBL.getCustomer(id); 
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<int> Post([FromBody] Customer customerToAdd)
        {
            return await customerBL.addNewCustomer(customerToAdd);
        }

        //PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody]Customer customerToUpdate)
        {
            customerBL.updateCustomer(customerToUpdate);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerBL.deleteCustomer(id);
        }
    }
}
