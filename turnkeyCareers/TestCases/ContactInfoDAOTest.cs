/*******************************
Developer: WA Pretoruis
Student  : 205093280
*******************************/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for ContactInfoDAOTest and is intended
    ///to contain all ContactInfoDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContactInfoDAOTest
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
        ///A test for isFound
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\careers\\careers", "/")]
        [UrlToTest("http://localhost:12075/")]
        public void ContactInfo_Test()
        {
            /*Context*/
            ContactInfoDAO contactInfo_context = new ContactInfoDAO();
            AccountDAO acc_context = new AccountDAO();
            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "griddy";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            ContactInfoDTO contact = new ContactInfoDTO();
            contact.userName = "griddy";
            contact.contactType = "skype";
            contact.data = "skippy";
            

            contactInfo_context.presist(contact);

            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = contactInfo_context.isFound("griddy", "skype");
            Assert.AreEqual(expected, actual);

            /*Update*/
            contact.data = "Gready";
            contactInfo_context.merge(contact);

            string expectedUpdate = "Gready";
            ContactInfoDTO contUpd = contactInfo_context.find("griddy", "skype");
            Assert.AreEqual(expectedUpdate, contUpd.data);

            /*Delete*/
            contactInfo_context.removeByUserId("griddy", "skype");

            bool expectedDelete = false;
            bool actualDelete = contactInfo_context.isFound("griddy", "skype");
            Assert.AreEqual(expectedDelete, actualDelete);

            acc_context.removeByUserId("griddy");

        }
    }
}
