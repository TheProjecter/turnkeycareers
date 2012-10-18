using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class InboxDAOTest
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
        public void InboxDAOConstructorTest()
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
            inbox.vacancyNumber = "1";
            inbox.unread = "read";
            inbox.userName = "griddy";
            inbox.status = "applied";

            inbox_context.presist(inbox);

            bool expected = true;
            bool actual;
            actual = inbox_context.isFound("griddy", "1");
            Assert.AreEqual(expected, actual);

            /*Update*/
            inbox.unread = "not read";
            inbox_context.merge(inbox);
            string expectedUpdate = "not read";
            InboxDTO contUpd = inbox_context.find("griddy", "1");
            Assert.AreEqual(expectedUpdate, contUpd.unread);

            /*Delete*/
            inbox_context.removeByUserId("griddy", "1");
            bool expectedDelete = false;
            bool actualDelete = inbox_context.isFound("griddy", "1");
            Assert.AreEqual(expectedDelete, actualDelete);

            account_context.removeByUserId("griddy");
        }
    }
}
