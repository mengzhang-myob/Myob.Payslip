namespace Myob.Payslip.Domain
{
    public class TaxBracket
    {
        public double Minimum { get; set; }
        public double? Maximum { get; set; }
        public double Basic { get; set; }
        public double Rate { get; set; }

        public TaxBracket(double minimum, double? maximum, double basic, double rate)
        {
            Minimum = minimum;
            Maximum = maximum;
            Basic = basic;
            Rate = rate;
        } 
    }
}