using System;

namespace Booking.BusinessLayer.DTOs
{
    public class Service
    {
        public Guid Id { get; set; }

        public Guid HotelId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}