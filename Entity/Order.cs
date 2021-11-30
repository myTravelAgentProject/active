using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan? EarlyCheckIn { get; set; }
        public TimeSpan? LateCheckOut { get; set; }
        public bool SeprateBeds { get; set; }
        public bool MultipleRooms { get; set; }
        public int? FloorHeight { get; set; }
        public int TotalPrice { get; set; }
        public int CostPrice { get; set; }
        public int? BookingId { get; set; }
        public int NumOfAdults { get; set; }
        public int? NumOfKids { get; set; }
        public int StatusCode { get; set; }
        public int? NewPrice { get; set; }
        public bool? Change { get; set; }
        public int HotelId { get; set; }
        public string Comments { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual Status StatusCodeNavigation { get; set; }
    }
}
