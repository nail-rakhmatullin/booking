using Booking.BusinessLayer.Abstract;
using Booking.BusinessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.BusinessLayer.Factories;
using Booking.BusinessLayer.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booking.Api.Controllers.Services
{
    [Route("api/[controller]/services")]
    [Produces("application/json")]
    [ApiController]
    public class HotelServiceController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IResponseFactory _responseFactory;

        public HotelServiceController(IHotelService hotelService, 
            IResponseFactory responseFactory)
        {
            _hotelService = hotelService;
            _responseFactory = responseFactory;
        }
        
        // GET:https://localhost:5000/api/HotelService/Services
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Service>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> RetrieveHotelServices()
        {
            IEnumerable<Service> services = await _hotelService.GetServices();
            return Ok(services);
        }
        
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkWebResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OkWebResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(OkWebResponse))]
        public async Task<IActionResult> CreateNewService([FromBody] Service service)
        {
            var dtoService = await _hotelService.CreateService(service);
            return Ok(_responseFactory.Create(body: dtoService));
        }


        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(OkWebResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OkWebResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(OkWebResponse))]
        public async Task<IActionResult> UpdateService([FromBody] Service service)
        {
            var dtoService = await _hotelService.EditService(service);
            return Ok(_responseFactory.Update(body: dtoService));
        }
    }
}
