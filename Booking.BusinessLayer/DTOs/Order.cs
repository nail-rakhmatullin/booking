using System;

namespace Booking.BusinessLayer.DTOs
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid ApplicationUserId { get; set; }

        public int PersonCount { get; set; }

        public Guid ApartmentId { get; set; }

        public DateTimeOffset CheckIn { get; set; }

        public DateTimeOffset CheckOut { get; set; }

        public decimal TotalPrice { get; set; }
    }
}