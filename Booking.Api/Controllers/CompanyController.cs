using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.BusinessLayer.Abstract;
using Booking.BusinessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Booking.BusinessLayer.Factories;
using Booking.BusinessLayer.Responses;

namespace Booking.Api.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  [Produces("application/json")]
  public class CompanyController : ControllerBase {
    private readonly ICompanyService _companyService;
    private readonly IResponseFactory _responseFactory;

    public CompanyController(ICompanyService companyService, IResponseFactory responseFactory) {
      _companyService = companyService;
      _responseFactory = responseFactory;
    }

    [HttpGet("GetCompanies")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkWebResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OkWebResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(OkWebResponse))]
    public async Task<IActionResult> RetrieveCompanies() {
      var companies = await _companyService.GetCompanies();
      return Ok(_responseFactory.Create(body: companies));
    }

    [HttpPost("AddCompany")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OkWebResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OkWebResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(OkWebResponse))]
    public async Task<IActionResult> AddCompany([FromBody] Company company) {
      await Task.Yield();
      var id = _companyService.AddCompany(company);
      return Ok(_responseFactory.Create(body: id));
    }

    [HttpPut("EditCompany")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(OkWebResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(OkWebResponse))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(OkWebResponse))]
    public async Task<IActionResult> EditCompany([FromBody] Company company) {
      var companyEdited = await _companyService.EditCompany(company);
      return Ok(_responseFactory.Update(body: companyEdited));
    }
  }
}