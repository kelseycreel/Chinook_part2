using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Chinook_part2.Data;
using Chinook_part2.Models;

namespace Chinook_part2.Controllers
{
    [Route("api/chinook")]
    [ApiController]
    public class ChinookController : ControllerBase
    {
        [HttpGet("customersbycountry/{country}")]
        public IActionResult GetCustomersByCountry(string country)
        {
            var _repository = new ChinookRepository();
            var customers = _repository.GetCustomersByCountry(country);
            if (!customers.Any())
                return NotFound();

            return Ok(customers);
        }

        [HttpGet("employeetitle/{title}")]
        public IActionResult GetEmployeeByTitle(string title)
        {
            var _repository = new ChinookRepository();
            var employees = _repository.GetEmployeesByTitle(title);

            return Ok(employees);
        }

        [HttpGet("salesagentcustomercount/{id}")]
        public IActionResult GetSalesAgentCustomerCount(int id)
        {
            var _repository = new ChinookRepository();
            var customerCount = _repository.GetSalesAgentCustomerCount(id);
            return Ok(customerCount);
        }

        [HttpGet("topsalesagent")]
        public IActionResult GetTopSalesAgent()
        {
            var _repository = new ChinookRepository();
            var salesAgent = _repository.GetTopSalesAgent();
            return Ok(salesAgent);
        }
    }
}