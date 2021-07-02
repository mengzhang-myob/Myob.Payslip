using System;
using Myob.Payslip.Domain;

namespace Myob.Payslip.Api.Models
{
    public class PayDetailsRequest
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string AnnualSalary { get; set; }
        public string SuperRate { get; set; }
        public string PayStartDate { get; set; }
        public string PayEndDate { get; set; }
        public class PayDetailsResponse
        {
            public string? PayPeriod { get; set; }
            public string? FullName { get; set; }
            public int? GrossIncome { get; set; }
            public int? IncomeTax { get; set; }
            public int? NetIncome { get; set; }
            public int? Super { get; set; }
            public int ResponseCode { get; set; }
            public string? ErrorMessage { get; set; }
            public PayDetailsResponse
            (
                string payPeriod, string fullName, int grossIncome, int incomeTax, int netIncome, int super,
                int responseCode
            )
            {
                PayPeriod = payPeriod;
                FullName = fullName;
                GrossIncome = grossIncome;
                IncomeTax = incomeTax;
                NetIncome = netIncome;
                Super = super;
                ResponseCode = responseCode;
            }
            public PayDetailsResponse(int responseCode, string errorMessage)
            {
                ResponseCode = responseCode;
                ErrorMessage = errorMessage;
            }
        }
    }
}