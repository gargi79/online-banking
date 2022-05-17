using System;
using NUnit.Framework;
using Authenticate;

namespace BankingSystemTest
{
    // This class to verify the user details according to data
    public class UserVarification
    {
        private UserVerification verification;

        [SetUp]
        public void Setup()
        {
            verification = new UserVerification(@"C:\Users\garhg\Desktop\cpts321-in-class-exercise\BankingSystem-Final\Authenticate\Authenticate\File.txt");
        }

        // Check data is correct 
        [Test]
        public void testLoginDetailsWithCorrectData()
        {
            Assert.AreEqual(verification.find("Cool","12345","User"),true);
        }

        //check data is  incorrect
        [Test]
        public void testLoginDetailsWithInCorrectData()
        {
            Assert.AreEqual(verification.find("Cool", "1234", "User"), false);
        }
    }
}
