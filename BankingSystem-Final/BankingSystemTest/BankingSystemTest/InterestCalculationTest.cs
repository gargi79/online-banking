using System;
using NUnit.Framework;
using InterestCalculation;

namespace BankingSystemTest
{
    //This class is check Interest is calculating correctly on not
    public class InterestCalculationTest
    {
        private Interest interest;

        [SetUp]
        public void Setup()
        {
            interest = new Interest();
        }

        // Check Yearly Interest Payment
        [Test]
        public void testYearlyInterest()
        {
            Assert.AreEqual(interest.getYearlyInterestPayment(15000, 0.5),900);
        }

        // Check Monthly Interest Payment
        [Test]
        public void testMonthlyInterest()
        {
            Assert.AreEqual(interest.getInterestRate(30000,0.5),150);
        }
    }
}
