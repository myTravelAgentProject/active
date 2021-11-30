using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Hotel
    {
        public Hotel()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PtoductUrl { get; set; }
        public string Accessibility { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Kosher { get; set; }
        public string Parking { get; set; }
        public string Phone { get; set; }
        public string Region { get; set; }
        public string SwimmingPool { get; set; }
        public string Url { get; set; }
        public string WiFi { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
