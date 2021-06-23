using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.BusinessLayer.Abstract
{
  public interface ICountryService
  {
        Task<IEnumerable<BusinessLayer.DTOs.Country>> GetCountries();
        Task<IEnumerable<BusinessLayer.DTOs.City>> GetCities();
  }
}