using Myob.Payslip.Domain;
using NUnit.Framework;


namespace Myob.Payslip.UnitTests
{
    public class PayDetailsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IncomeTax_ShouldFallIntoFirstBracket()
        {
            var salary = 17000;
            var super = 9;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(1416, payDetails.GrossIncome);
            Assert.AreEqual(0, payDetails.IncomeTax);
            Assert.AreEqual(1416, payDetails.NetIncome);
            Assert.AreEqual(127, payDetails.Super);
        }
        [Test]
        public void IncomeTax_ShouldFallIntoSecondBracket()
        {
            var salary = 23000;
            var super = 9.5;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(1916, payDetails.GrossIncome);
            Assert.AreEqual(76, payDetails.IncomeTax);
            Assert.AreEqual(1840, payDetails.NetIncome);
            Assert.AreEqual(182, payDetails.Super);
        }
        
        [Test]
        public void IncomeTax_ShouldFallIntoThirdBracket()
        {
            var salary = 40000;
            var super = 9.5;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(3333, payDetails.GrossIncome);
            Assert.AreEqual(379, payDetails.IncomeTax);
            Assert.AreEqual(2954, payDetails.NetIncome);
            Assert.AreEqual(316, payDetails.Super);
        }
        [Test]
        public void IncomeTax_ShouldFallIntoFourthBracket()
        {
            var salary = 91000;
            var super = 9.5;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(7583, payDetails.GrossIncome);
            Assert.AreEqual(1776, payDetails.IncomeTax);
            Assert.AreEqual(5807, payDetails.NetIncome);
            Assert.AreEqual(720, payDetails.Super);
        }
        [Test]
        public void IncomeTax_ShouldFallIntoFifthBracket()
        {
            var salary = 200000;
            var super = 9.5;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(16666, payDetails.GrossIncome);
            Assert.AreEqual(5270, payDetails.IncomeTax);
            Assert.AreEqual(11396, payDetails.NetIncome);
            Assert.AreEqual(1583, payDetails.Super);
        }
        [Test]
        public void IncomeTax_ShouldPositiveIfNegative()
        {
            var salary = -40000;
            var super = 9.5;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(3333, payDetails.GrossIncome);
            Assert.AreEqual(379, payDetails.IncomeTax);
            Assert.AreEqual(2954, payDetails.NetIncome);
            Assert.AreEqual(316, payDetails.Super);
        }
        [Test]
        public void IncomeTax_ShouldBeZeroIfZero()
        {
            var salary = 0;
            var super = 9.5;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(0, payDetails.GrossIncome);
            Assert.AreEqual(0, payDetails.IncomeTax);
            Assert.AreEqual(0, payDetails.NetIncome);
            Assert.AreEqual(0, payDetails.Super);
        }
        [Test]
        public void IncomeTax_SuperRateShouldBePositiveIfNegative()
        {
            var salary = 50000;
            var super = -9.5;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(4166, payDetails.GrossIncome);
            Assert.AreEqual(650, payDetails.IncomeTax);
            Assert.AreEqual(3516, payDetails.NetIncome);
            Assert.AreEqual(395, payDetails.Super);
        }
        
        [Test] public void IncomeTax_ShouldFallInTheLastBracket_IfSalaryExactlyEqualsBracketMinimum()
        {
            var salary = 180000.5;
            var super = 9.5;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(15000, payDetails.GrossIncome);
            Assert.AreEqual(4520, payDetails.IncomeTax);
            Assert.AreEqual(10480, payDetails.NetIncome);
            Assert.AreEqual(1425, payDetails.Super);
        }
        
        [Test] 
        public void IncomeTax_ShouldFallInTheMiddleBracket_IfSalaryExactlyEqualsBracketMinimum()
        {
            var salary = 87000.5;
            var super = 9.5;
            var payDetails = new PayDetails();
            payDetails.TrySetAnnualSalary(salary.ToString());
            payDetails.calcIncomeTax();
            payDetails.TrySetSuperRate(super.ToString());
            Assert.AreEqual(7250, payDetails.GrossIncome);
            Assert.AreEqual(1652, payDetails.IncomeTax);
            Assert.AreEqual(5598, payDetails.NetIncome);
            Assert.AreEqual(688, payDetails.Super);
        }
    }
}