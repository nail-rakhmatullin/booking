using System.ComponentModel.DataAnnotations;

namespace Booking.BusinessLayer.DTOs
{
    public class LoginRequest
    {
        [Required]
        [StringLength(55)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
    }
}