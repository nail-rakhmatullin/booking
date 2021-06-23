using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.BusinessLayer.Abstract;
using Booking.BusinessLayer.DTOs;
using Booking.BusinessLayer.Factories;
using Booking.BusinessLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IResponseFactory _responseFactory;

        public HotelController(IHotelService hotelService, IResponseFactory responseFactory)
        {
            _hotelService = hotelService;
            _responseFactory = responseFactory;
        }

        [HttpGet("GetHotels")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Hotel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OkWebResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(OkWebResponse))]
        public async Task<IActionResult> RetrieveHotels()
        {
            var hotels = await _hotelService.GetHotels();
            return Ok(hotels);
        }

        [HttpPost("AddHotel")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkWebResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OkWebResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(OkWebResponse))]
        public async Task<IActionResult> AddHotel([FromBody] Hotel hotel)
        {
            await Task.Yield();
            var id = _hotelService.AddHotel(hotel);
            return Ok(_responseFactory.Create(id));
        }

        [HttpPut("EditHotel")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(OkWebResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OkWebResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(OkWebResponse))]
        public async Task<IActionResult> EditHotel([FromBody] Hotel hotel)
        {
            var hotelEdited = await _hotelService.EditHotel(hotel);
            return Ok(_responseFactory.Update(hotelEdited));
        }
    }
}