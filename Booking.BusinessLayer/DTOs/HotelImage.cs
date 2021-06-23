using System;

namespace Booking.BusinessLayer.DTOs
{
    public class HotelImage
    {
        public Guid Id { get; set; }

        public byte[] Source { get; set; }
    }
}