using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;

namespace Booking.BusinessLayer.DTOs
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}