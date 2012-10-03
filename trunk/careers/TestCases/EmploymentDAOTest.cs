using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for EmploymentDAOTest and is intended
    ///to contain all EmploymentDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmploymentDAOTest
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
        public void EmploymentDAO_Test()
        {
            /*Context*/
            EmploymentDAO emp_context = new EmploymentDAO();
            AccountDAO account_context = new AccountDAO();

            /*Insert*/
            AccountDTO account = new AccountDTO();
            account.userName = "griddy";
            account.status = "active";
            account.password = "greddy";
            account.accountType = "admin";

            account_context.presist(account);

            EmploymentDTO employment = new EmploymentDTO();
            employment.company = "fuzion";
            employment.country = "SA";
            employment.currentEmployer = "Apple";
            employment.empType = "Contract";
            employment.endDate = new DateTime(2012, 12, 30);
            employment.gross = 10000;
            employment.industry = "IT";
            employment.province = "WP";
            employment.responsibilities = "web development";
            employment.startDate = new DateTime(2012, 6, 7);
            employment.title = "web developer";
            employment.town = "cape town";
            employment.userName = "griddy";

            emp_context.presist(employment);

            bool expected = true;
            bool actual;
            actual = emp_context.isFound("griddy", new DateTime(2012, 6, 7) );
            Assert.AreEqual(expected, actual);

            /*Update*/
            employment.gross = 125000;
            emp_context.merge(employment);

            double expectedUpdate = 125000;
            EmploymentDTO contUpd = emp_context.find("griddy", new DateTime(2012, 6, 7));
            Assert.AreEqual(expectedUpdate, contUpd.gross);

            /*Delete*/
            emp_context.removeByUserId("griddy", new DateTime(2012, 6, 7));
            bool expectedDelete = false;
            bool actualDelete = emp_context.isFound("griddy", new DateTime(2012, 6, 7));
            Assert.AreEqual(expectedDelete, actualDelete);

            account_context.removeByUserId("griddy");
            
        }
    }
}
