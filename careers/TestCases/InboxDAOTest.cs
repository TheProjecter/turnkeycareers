using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for InboxDAOTest and is intended
    ///to contain all InboxDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InboxDAOTest
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
        public void InboxDAO_Test()
        {
            /*Context*/
            InboxDAO inbox_context = new InboxDAO();
            AccountDAO account_context = new AccountDAO();

            /*Insert*/
            AccountDTO account = new AccountDTO();
            account.userName = "griddy";
            account.status = "active";
            account.password = "greddy";
            account.accountType = "admin";

            account_context.presist(account);

            InboxDTO inbox = new InboxDTO();
            inbox.date = new DateTime(2012, 9, 30);
            inbox.message = "success";
            inbox.messageId = 1;
            inbox.unread = "read";
            inbox.userName = "griddy";

            inbox_context.presist(inbox);

            bool expected = true;
            bool actual;
            actual = inbox_context.isFound("griddy", 1);
            Assert.AreEqual(expected, actual);

            /*Update*/
            inbox.unread = "not read";
            inbox_context.merge(inbox);
            string expectedUpdate = "not read";
            InboxDTO contUpd = inbox_context.find("griddy", 1);
            Assert.AreEqual(expectedUpdate, contUpd.unread);

            /*Delete*/
            inbox_context.removeByUserId("griddy", 1);
            bool expectedDelete = false;
            bool actualDelete = inbox_context.isFound("griddy", 1);
            Assert.AreEqual(expectedDelete, actualDelete);

            account_context.removeByUserId("griddy");

        }
    }
}
