using System.Threading.Tasks;
using Booking.BusinessLayer.Responses;
using Booking.DataLayer.Tables.Users;

namespace Booking.BusinessLayer.Abstract
{
    public interface IClaimService
    {
        Task<UserManagerResponse> GetClaims(ApplicationUser user, params string[] roles);
    }
}