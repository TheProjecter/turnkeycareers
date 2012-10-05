
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 5 October 2012
 * Testing Services: 
 *      getInboxMessagesByDate
 *      getInboxMessagesByMessage
 *      getInboxMessagesByUsername 
 *      getUserInboxMessagesByDate 
 *      getUserInboxMessagesByMessage 
 * ********************************************************/

using careers.SERVICES.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for InboxMessageSearchServiceTest and is intended
    ///to contain all InboxMessageSearchServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InboxMessageSearchServiceTest
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


        internal virtual InboxMessageSearchService CreateInboxMessageSearchService()
        {
            // TODO: Instantiate an appropriate concrete class.
            InboxMessageSearchService target = new InboxMessageSearchServiceImpl();
            return target;
        }

        /// <summary>
        ///A test for getInboxMessagesByUsername
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\careers\\careers", "/")]
        [UrlToTest("http://localhost:12075/")]
        public void inboxMessagesTest()
        {
            InboxMessageSearchService inboxMessageSearchService = CreateInboxMessageSearchService();
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

            //Test getInboxMessagesByDate method
            List<InboxDTO> inboxList = inboxMessageSearchService.getInboxMessagesByDate(new DateTime(2012, 9, 30));
            Assert.AreEqual(inbox.userName, inboxList[0].userName);

            //Test getInboxMessagesByMessage method
            List<InboxDTO> inboxList2 = inboxMessageSearchService.getInboxMessagesByMessage("success");
            Assert.AreEqual(inbox.userName, inboxList2[0].userName);

            //Test getInboxMessagesByUsername method
            List<InboxDTO> inboxList3 = inboxMessageSearchService.getInboxMessagesByUsername("griddy");
            Assert.AreEqual(inbox.userName, inboxList3[0].userName);

            //Test getUserInboxMessagesByDate method
            List<InboxDTO> inboxList4 = inboxMessageSearchService.getUserInboxMessagesByDate("griddy", new DateTime(2012, 9, 30));
            Assert.AreEqual(inbox.userName, inboxList4[0].userName);

            //Test getUserInboxMessagesByMessage method
            List<InboxDTO> inboxList5 = inboxMessageSearchService.getUserInboxMessagesByMessage("griddy", "success");
            Assert.AreEqual(inbox.userName, inboxList5[0].userName);

            /*Delete*/
            inbox_context.removeByUserId("griddy", 1);
            bool expectedDelete = false;
            bool actualDelete = inbox_context.isFound("griddy", 1);
            Assert.AreEqual(expectedDelete, actualDelete);

            account_context.removeByUserId("griddy");
        }
    }
}
