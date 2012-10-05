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
    ///This is a test class for AddressDAOTest and is intended
    ///to contain all AddressDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AddressDAOTest
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
        ///A test for AddressDAO Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\careers\\careers", "/")]
        [UrlToTest("http://localhost:12075/")]
        public void AddressDAO_Test()
        {
            /*Context*/
            AccountDAO acc_context = new AccountDAO();
            AddressDAO address_context = new AddressDAO();
            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "griddy";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            Assert.AreEqual(true,acc_context.presist(acc) );
            
            AddressDTO address = new AddressDTO();
            address.userName = "griddy";
            address.addressType = "postal";
            address.country = "South Africa";
            address.province = "WP";
            address.street = "Frans";
            address.suburb = "Parow";
            address.town = "Cape Town";
            address.unitNumber = 22;
            
            Assert.AreEqual(true,address_context.presist(address) );
            /*Update*/
            address.town = "Pretoria";
            address_context.merge(address);

            string expectedUpdate = "Pretoria";
            AddressDTO upd = address_context.find("griddy", "postal");
            Assert.AreEqual(expectedUpdate, upd.town);

            /*Delete*/
            address_context.removeByUserId("griddy", "postal");
            bool expectedDelAddress = false;
            bool actualDeleteAddress = address_context.isFound("griddy", "postal");
            Assert.AreEqual(expectedDelAddress, actualDeleteAddress);

            acc_context.removeByUserId("griddy");
           
        }
    }
}
