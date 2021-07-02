using Myob.Payslip.Api.Models;
using Myob.Payslip.Domain;

namespace Myob.Payslip.Api.Services
{
    public class PayDetailsService
    {
        public PayDetailsRequest.PayDetailsResponse CalculateTax (PayDetailsRequest request)
        {
            PayDetails payDetails = new PayDetails()
            {
                FirstName = request.FirstName,
                SurName = request.SurName,
                PayStartDate = request.PayStartDate,
                PayEndDate = request.PayEndDate
            };
            bool isValueValid = payDetails.TrySetSuperRate(request.SuperRate) && payDetails.TrySetAnnualSalary(request.AnnualSalary);
            if (isValueValid)
            {
                return new PayDetailsRequest.PayDetailsResponse(
                    payDetails.PayPeriod, 
                    payDetails.FullName, 
                    payDetails.GrossIncome, 
                    payDetails.IncomeTax, 
                    payDetails.NetIncome, 
                    payDetails.Super, 
                    200);
            }
            // do we reject ?  throw exception ? throw new exception 
            
            /*TODO: map the methods in the payDetail object*/

            // fill out response object from paydetails 

            return new PayDetailsRequest.PayDetailsResponse(422, "Invalid input values");

        }
    }
}