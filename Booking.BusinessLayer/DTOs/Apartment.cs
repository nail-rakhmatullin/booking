using System;

namespace Booking.BusinessLayer.DTOs
{
    public class Apartment
    {
        public Guid Id { get; set; }

        public Guid HotelId { get; set; }

        public int RoomTypeId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}