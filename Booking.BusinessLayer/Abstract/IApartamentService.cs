using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.BusinessLayer.DTOs;

namespace Booking.BusinessLayer.Abstract
{
    public interface IApartamentService
    {
        Task<IEnumerable<Apartment>> GetApataments();
    }
}