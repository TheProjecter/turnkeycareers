using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for LicenseDAOTest and is intended
    ///to contain all LicenseDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LicenseDAOTest
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
        public void LicenseDAO_Test()
        {
             
            /*Context*/
            AccountDAO acc_context = new AccountDAO();
            LicenseDAO lic_context = new LicenseDAO();
            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "griddy";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            LicenseDTO lic = new LicenseDTO();
            lic.userName = "griddy";
            lic.type = "car";

            lic_context.presist(lic);
            Assert.AreEqual(lic.type, lic_context.find("griddy").type);

            /*Update*/
            lic.type = "bike";
            lic_context.merge(lic);
            Assert.AreEqual("bike", lic_context.find("griddy").type);

            /*Delete*/
            lic_context.removeByUserId("griddy");
            Assert.AreEqual(lic_context.isFound("griddy"), false);

            acc_context.removeByUserId("griddy");
        }
    }
}
