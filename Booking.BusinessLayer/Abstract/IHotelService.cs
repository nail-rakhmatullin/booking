using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.BusinessLayer.DTOs;

namespace Booking.BusinessLayer.Abstract
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotels();
        Guid AddHotel(Hotel hotel);
        Task<Hotel> EditHotel(Hotel hotel);
        Task<IEnumerable<Service>> GetServices();
        Task<Service> CreateService(Service service);
        Task<Service> EditService(Service service);
    }
}