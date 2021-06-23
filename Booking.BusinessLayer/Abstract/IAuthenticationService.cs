using System.Threading.Tasks;
using Booking.BusinessLayer.DTOs;
using Booking.BusinessLayer.Responses;

namespace Booking.BusinessLayer.Abstract
{
    public interface IAuthenticationService
    {
        Task<UserManagerResponse> RegisterAsync(RegisterRequest request);
        Task<UserManagerResponse> LoginAsync(LoginRequest request);
    }
}