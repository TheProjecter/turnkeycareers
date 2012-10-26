using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class DisabilityDAOTest
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
        public void DisabilityDAOConstructorTest()
        {
            /*Context*/
            DisabilityDAO disability_context = new DisabilityDAO();
            AccountDAO account_context = new AccountDAO();
            /*Insert*/
            AccountDTO account = new AccountDTO();
            account.userName = "john";
            account.status = "active";
            account.password = "greddy";
            account.accountType = "admin";

            account_context.presist(account);

            DisabilityDTO disability = new DisabilityDTO();
            disability.disabilityType = "hearing";
            disability.description = "loss of hearing";
            disability.userName = "john";

            disability_context.presist(disability);

            bool expected = true;
            bool actual;
            actual = disability_context.isFound("john", "hearing");
            Assert.AreEqual(expected, actual);

            /*Update*/
            disability.description = "no hearing";
            disability_context.merge(disability);
            string expectedUpdate = "no hearing";
            DisabilityDTO contUpd = disability_context.find("john", "hearing");
            Assert.AreEqual(expectedUpdate, contUpd.description);

            /*Delete*/
            disability_context.removeByUserId("john", "hearing");

            bool expectedDelete = false;
            bool actualDelete = disability_context.isFound("john", "hearing");
            Assert.AreEqual(expectedDelete, actualDelete);

            account_context.removeByUserId("john");
        }
    }
}
