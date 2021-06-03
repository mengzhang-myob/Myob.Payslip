using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Myob.Payslip.Domain;

namespace Myob.Payslip.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayDetailsContoller : Controller
    {
        private readonly ILogger<PayDetailsContoller> _logger;

        public PayDetailsContoller(ILogger<PayDetailsContoller> logger)
        {
            _logger = logger;
        }

        // POST
        [HttpPost]
        public string Post(PayDetails payDetail)
        {
            return (
                "Your payslip has been generated:\n" +
                "Name: " + payDetail.FullName + "\n" +
                "Pay Period: " +payDetail.PayPeriod + "\n" +
                "Gross Income: " + payDetail.GrossIncome + "\n" +
                "Income Tax: " + payDetail.IncomeTax + "\n" +
                "Net Income: " + payDetail.NetIncome + "\n" +
                "Super: " + payDetail.Super + "\n" + "\n" +
                "Thank you for using MYOB!"
                ); 
        }
    }
}