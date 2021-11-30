using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
    public class orderDL : IOrderDL
    {
        MyTravelAgentContext myTravelAgentContext;
        public orderDL(MyTravelAgentContext myTravelAgentContext)
        {
            this.myTravelAgentContext = myTravelAgentContext;
        }

        public async Task<List<OrderForCalendar>> getEventsForCalender(DateTime startDate, DateTime endDate)
        {
            List<OrderForCalendar> ordersToShow = new List<OrderForCalendar>();
            //var orderListToShow = await myTravelAgentDBContext.Orders.Join(myTravelAgentDBContext.Customers, order => order.CustomerId, customer => customer.Id, (order, customer) => new {
            //    order.Id,customer.FirstName,customer.LastName,order.HotelId,order.CheckInDate,
            //    order.CheckOutDate,order.EarlyCheckIn,order.LateCheckOut })
            //    .Join(myTravelAgentDBContext.Hotels, newOrder => newOrder.HotelId, hotel => hotel.Id, (newOrder, hotel) => new {
            //    newOrder.Id,newOrder.FirstName,newOrder.LastName,hotel.Name,newOrder.CheckInDate,newOrder.CheckOutDate,newOrder.EarlyCheckIn,newOrder.LateCheckOut})
            //                .Where(order => order.CheckInDate >= startDate && order.CheckInDate <= endDate)
            //                .ToListAsync();

            ordersToShow = (from o in myTravelAgentContext.Orders
                                       //join c in myTravelAgentDBContext.Customers on o.CustomerId equals c.Id
                                   where o.CheckInDate >= startDate && o.CheckInDate <= endDate
                                   select new OrderForCalendar {
                                       orderId = o.Id,
                                       customerName=o.Customer.FirstName +" "+ o.Customer.LastName,
                                    //    hotelName = o.Hotel.Name,
                                        checkInDate=o.CheckInDate,
                                        checkOutDate=o.CheckOutDate,
                                        earlyCheckIn=o.EarlyCheckIn,
                                        lateCheckOut=o.LateCheckOut
                                   }).ToList();

           
            return  ordersToShow;
        }
    }
}
