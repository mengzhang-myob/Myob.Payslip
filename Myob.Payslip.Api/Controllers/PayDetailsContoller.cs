using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Myob.Payslip.Api.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Myob.Payslip.Api.Services;

namespace Myob.Payslip.Api.Controllers
{
    [ApiController]
    [Route("PayDetails")]
    public class PayDetailsContoller : Controller
    {
        private readonly ILogger<PayDetailsContoller> _logger;

        public PayDetailsContoller(ILogger<PayDetailsContoller> logger)
        {
            _logger = logger;
        }

        // POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        /*I use 422 here because it best describes the error type: an invalid data is provided in the request body*/
        public IActionResult Post(PayDetailsRequest request)
        {
            //CalculateTax  try / catch 
            var service = new PayDetailsService();
            var response = service.CalculateTax(request);
            if (response.ResponseCode == 200)
            {
                return Ok(JsonSerializer.Serialize(response));
            }
            return UnprocessableEntity();
                ; /*json.Stringfy*/
                /*My finding: C# doesn't have json.Stringfy, it is JsonSerializer.Serialize(myObject) instead*/
            /*response code to be configured here in the controller*/
        }
    }
}