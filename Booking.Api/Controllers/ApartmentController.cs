using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.BusinessLayer.Abstract;
using Booking.BusinessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ApartmentController : Controller
    {
        private readonly IApartamentService _apartamentService;

        public ApartmentController(IApartamentService apartamentService)
        {
            _apartamentService = apartamentService;
        }

        [HttpGet("apartament")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Apartment>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> RetrieveApartaments()
        {
            var apartments = await _apartamentService.GetApataments();
            return Ok(apartments);
        }
    }
}