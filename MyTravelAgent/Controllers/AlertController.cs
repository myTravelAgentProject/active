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
    public class AlertController : ControllerBase
    {
        public IAlertBL alertBL;

        public AlertController(IAlertBL alertBL)
        {
            this.alertBL = alertBL;
        }
        // GET: api/<AlertController>
        [HttpGet]
        public async Task<List<Alert>> Get(DateTime today)
        {
            return await alertBL.getRelevantAlerts(today);
        }
       
        //// GET api/<AlertController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AlertController>
        [HttpPost]
        public async Task<int> Post([FromBody] Alert newAlert)
        {
            return await alertBL.insertAlert(newAlert);
        }

        // PUT api/<AlertController>/5
        [HttpPut]
        public void Put( [FromBody] Alert alertToUpdate)
        {
            alertBL.updateAlert(alertToUpdate);
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            alertBL.deleteAlert(id);
        }
    }
}
