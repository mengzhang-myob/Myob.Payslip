using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Myob.Payslip.Api.Controllers;
using Myob.Payslip.Api.Models;
using Xunit;

namespace Myob.Payslip.ApiTests
{
    public class PaySlipApiTest
    {
        private PayDetailsRequest testResquest = new PayDetailsRequest();
        private readonly ILogger<PayDetailsContoller> _logger;

        [Fact]
        public async Task shouldReturnStatus200WhenRequestIsValid()
        {
            // Arrange
            testResquest.FirstName = "Meng";
            testResquest.SurName = "Zhang";
            testResquest.AnnualSalary = "60000";
            testResquest.SuperRate = "9.5";
            testResquest.PayStartDate = "sss";
            testResquest.PayEndDate = "eee";
            var mockController = new PayDetailsContoller(_logger);
            // Act
            var actionResult = mockController.Post(testResquest);
            var okResult = actionResult as OkObjectResult;
            // Assert
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(
                JsonSerializer.Serialize(new PayDetailsRequest.PayDetailsResponse(
                    "sss - eee",
                    "Meng Zhang",
                    5000,
                    921,
                    4079,
                    475,
                    200
                )), okResult.Value);
        }

        [Fact]
        public async Task shouldReturnStatus422WhenRequestIsValid()
        {
            // Arrange
            testResquest.FirstName = "Meng";
            testResquest.SurName = "Zhang";
            testResquest.AnnualSalary = "60000oo";
            testResquest.SuperRate = "9.5";
            testResquest.PayStartDate = "sss";
            testResquest.PayEndDate = "eee";
            var mockController = new PayDetailsContoller(_logger);
            // Act
            var actionResult = mockController.Post(testResquest);
            var UnprocessableEntityResult = actionResult as UnprocessableEntityResult;
            // Assert
            Assert.Equal(422, UnprocessableEntityResult.StatusCode);
        }
    }
}