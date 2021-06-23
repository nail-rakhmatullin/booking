using System;

namespace Booking.BusinessLayer.DTOs
{
    public class Check
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
    }
}