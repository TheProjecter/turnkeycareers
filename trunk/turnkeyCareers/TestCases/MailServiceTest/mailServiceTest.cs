/*******************************
Developer: WA Pretoruis
Student  : 205093280
*******************************/
using careers.SERVICES;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for SecurityServiceTest and is intended
    ///to contain all SecurityServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class mailServiceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for sendMail
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\careers\\careers", "/")]
        [UrlToTest("http://localhost:12075/")]
        public void sendMail_Test()
        {
         /* Results
         * 4 Unable to send E-mail - contact administrator
         * 5 E-mail successfully sent
         */
            mailService sec_context = new mailService(); // TODO: Initialize to an appropriate value
            string destinationAddress = "mailgriddy@gmail.com";
            string msgBody = "Test"; // TODO: Initialize to an appropriate value
            Assert.AreEqual(sec_context.sendMail(destinationAddress, msgBody), 4); //Password not set
            
        }

        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\careers\\careers", "/")]
        [UrlToTest("http://localhost:12075/")]
        public void forgotPassword_Test()
        {
         /*
         * 1 Successfull
         * 2 Invalid User
         * 3 E-mail Address not found
         * 4 Unable to send E-mail - contact administrator
         * 5 E-mail successfully sent
         */
            mailService sec_context = new mailService(); // TODO: Initialize to an appropriate value
            AccountDAO target = new AccountDAO();
            ContactInfoDAO cont_context = new ContactInfoDAO();

            string msgBody = "Test: PASSWORD."; // TODO: Initialize to an appropriate value
            Assert.AreNotEqual(sec_context.forgotPassword("griddy", msgBody), 1); //Invalid User
            Assert.AreEqual(sec_context.forgotPassword("griddy", msgBody), 2); //Invalid User
            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "griddy";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            target.presist(acc);

            Assert.AreEqual(sec_context.forgotPassword("griddy", msgBody), 3); //E-mail Address not found

            ContactInfoDTO contact = new ContactInfoDTO();
            contact.userName = "griddy";
            contact.contactType = "e-mail";
            contact.data = "mailgriddy@gmail.com";

            cont_context.presist(contact);
            Assert.AreEqual(sec_context.forgotPassword("griddy", msgBody), 4); //Unable to send E-mail - contact administrator

            /*Delete*/
            cont_context.removeByUserId("griddy", "e-mail");
            target.removeByUserId("griddy");



        }
    }
}
