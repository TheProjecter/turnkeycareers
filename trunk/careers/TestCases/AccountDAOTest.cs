using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for AccountDAOTest and is intended
    ///to contain all AccountDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AccountDAOTest
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
        public void AccountDAO_Test()
        {
            /*Context*/
            AccountDAO target = new AccountDAO(); 
            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "griddy";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            target.presist(acc);

            string userName = "griddy"; // TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.isFound(userName);
            Assert.AreEqual(expected, actual);

            /*Update*/
            acc.status = "inactive";
            target.merge(acc);

            string expectedUpdate = "inactive";
            AccountDTO upd =  target.find("griddy");
            Assert.AreEqual(expectedUpdate, upd.status);

            /*Delete*/
            target.removeByUserId("griddy");
            bool expectedDelete = false;
            bool actualDelete = target.isFound("griddy");
            Assert.AreEqual(expectedDelete, actualDelete);


        }
    }
}
