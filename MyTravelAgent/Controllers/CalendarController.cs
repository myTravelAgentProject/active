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
    public class EventsController : ControllerBase
    {

        IOrderBL orderBL;
        IAlertBL alertBL;
        public EventsController(IOrderBL orderBL, IAlertBL alertBL)
        {
            this.alertBL = alertBL;
            this.orderBL = orderBL;
        }
        // GET: api/<EventsController>
        [HttpGet]
        public void Get()
        {
            Console.WriteLine("hi");
        }

        // all events in month
        [HttpGet]
        [Route("calendar_orders/{year}/{month}")]
        public async Task<List<OrderForCalendar>> GetOrders(int year, int month)
        {
            DateTime beginingOfMonth = new DateTime(year, month, 01);
            int days = DateTime.DaysInMonth(year, month);
            DateTime endOfMonth = new DateTime(year, month, days);
            return await orderBL.getEventsForCalender(beginingOfMonth, endOfMonth);

        }

        //all events in week
        [HttpGet]
        [Route("calendar_orders/{date}")]
        public async Task<List<OrderForCalendar>> GetOrders(DateTime date)
        {
            int dayOfWeek = (int)date.DayOfWeek;
            DateTime beginingOfWeek = date.AddDays(-dayOfWeek + 1);
            DateTime endOfWeek = beginingOfWeek.AddDays(6);
            return await orderBL.getEventsForCalender(beginingOfWeek, endOfWeek);
        }

        // all alerts in month
        [HttpGet]
        [Route("calendar_alerts/{year}/{month}")]
        public async Task<List<Alert>> GetAlerts(int year, int month)
        {
            DateTime beginingOfMonth = new DateTime(year, month, 01);
            int days = DateTime.DaysInMonth(year, month);
            DateTime endOfMonth = new DateTime(year, month, days);
            return await alertBL.getAlertsForCalender(beginingOfMonth, endOfMonth);
        }

        //all events in week
        [HttpGet]
        [Route("calendar_alerts/{date}")]
        public async Task<List<Alert>> GetAlerts(DateTime date)
        {
            int dayOfWeek = (int)date.DayOfWeek;
            DateTime beginingOfWeek = date.AddDays(-dayOfWeek + 1);
            DateTime endOfWeek = beginingOfWeek.AddDays(6);
            return await alertBL.getAlertsForCalender(beginingOfWeek, endOfWeek);
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
