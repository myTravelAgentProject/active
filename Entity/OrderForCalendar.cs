using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderForCalendar
    {
        public int orderId { get; set; }
        public string customerName { get; set; }
        public string hotelName { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public TimeSpan? earlyCheckIn { get; set; }
        public TimeSpan? lateCheckOut { get; set; }
        
    }
}
