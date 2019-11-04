using System;
using System.Collections.Generic;
using CompanyApi.Domain.Interfaces.Services;
using CompanyApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public IList<Company> GetAll()
        {
            try
            {
                return _companyService.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("GetByUserId/{userId}")]
        [MapToApiVersion("1.0")]
        public IActionResult GetByUserId(string userId)
        {
            try
            {
                return Ok(_companyService.GetCompaniesByUserId(userId));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public IActionResult AddCompany(Company company)
        {
            try
            {
                return Ok(_companyService.AddCompany(company));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        public IActionResult UpdateCompany(Company company)
        {
            try
            {
                return Ok(_companyService.UpdateCompany(company));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
