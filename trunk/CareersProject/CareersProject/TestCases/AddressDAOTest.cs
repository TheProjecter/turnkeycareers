using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class AddressDAOTest
    {


        private TestContext testContextInstance;

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


        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("%PathToWebRoot%\\..\\CareersProject\\DAL\\DAL", "/")]
        [UrlToTest("http://localhost:3534/")]
        public void AddressDAOConstructorTest()
        {
            /*Context*/
            AccountDAO acc_context = new AccountDAO();
            AddressDAO address_context = new AddressDAO();
            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "john";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            Assert.AreEqual(true, acc_context.presist(acc));

            AddressDTO address = new AddressDTO();
            address.userName = "john";
            address.addressType = "postal";
            address.country = "South Africa";
            address.province = "WP";
            address.street = "Frans";
            address.suburb = "Parow";
            address.town = "Cape Town";
            address.unitNumber = 22;

            Assert.AreEqual(true, address_context.presist(address));
            /*Update*/
            address.town = "Pretoria";
            address_context.merge(address);

            string expectedUpdate = "Pretoria";
            AddressDTO upd = address_context.find("john", "postal");
            Assert.AreEqual(expectedUpdate, upd.town);

            /*Delete*/
            address_context.removeByUserId("john", "postal");
            bool expectedDelAddress = false;
            bool actualDeleteAddress = address_context.isFound("john", "postal");
            Assert.AreEqual(expectedDelAddress, actualDeleteAddress);

            acc_context.removeByUserId("john");
        }
    }
}
