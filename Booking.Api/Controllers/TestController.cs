using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.BusinessLayer.Abstract;
using Booking.BusinessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Booking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TestController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public TestController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // https://localhost:5000/api/test/check
        [HttpGet("check")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> CheckService()
        {
            Log.Information("Test controller start");
            await Task.Yield();
            return Ok("Service is working!");
        }

        // https://localhost:5000/api/test/countries
        [HttpGet("countries")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> RetrieveCountries()
        {
            var countries = await _countryService.GetCountries();
            return Ok(countries);
        }

        [HttpGet("cities")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<City>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> RetrieveCities()
        {
            var cities = await _countryService.GetCities();
            return Ok(cities);
        }
    }
}