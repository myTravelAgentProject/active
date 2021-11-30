using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerChildren = new HashSet<CustomerChild>();
            Orders = new HashSet<Order>();
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? NumOfAdults { get; set; }
        public int? NumOfKids { get; set; }
        public bool? HighFloor { get; set; }
        public bool? Porch { get; set; }
        public bool? SeprateBeds { get; set; }
        public bool? MultipleRooms { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<CustomerChild> CustomerChildren { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
