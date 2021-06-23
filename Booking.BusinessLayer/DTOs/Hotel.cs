using System;

namespace Booking.BusinessLayer.DTOs
{
    public class Hotel
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AdditionalInfo { get; set; }

        public string Address { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public double Rate { get; set; }

        public int CityId { get; set; }
    }
}