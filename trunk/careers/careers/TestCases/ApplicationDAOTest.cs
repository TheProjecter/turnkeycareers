using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for ApplicationDAOTest and is intended
    ///to contain all ApplicationDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ApplicationDAOTest
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
        [AspNetDevelopmentServerHost("C:\\careers\\careers\\careers", "/")]
        [UrlToTest("http://localhost:12075/")]
        public void ApplicationDAO_Test()
        {
            AccountDAO account_context = new AccountDAO();
            ApplicationDAO app_context = new ApplicationDAO();
            VacancyDAO vac_context = new VacancyDAO();
            
            /*Insert*/
            AccountDTO account = new AccountDTO();
            account.userName = "griddy";
            account.status = "active";
            account.password = "greddy";
            account.accountType = "admin";

            account_context.presist(account);

            VacancyDTO vac = new VacancyDTO();
            vac.department = "IS";
            vac.description = "Web services";
            vac.manager = "Tom";
            vac.recruiter = "Thumi";
            vac.site = "www.petrosa.co.za";
            vac.startDate = new DateTime(2012, 10, 10);
            vac.endDate = new DateTime(2012, 12, 1);
            vac.description = "desktop support";
            vac.title = "support technician";
            vac.vacancyNumber = "1";
            vac.viewCount = 10;
            vac.viewStatus = "published";
            vac.status = "active";

            vac_context.presist(vac);
            bool expectedVac = true;
            bool actualVac;
            actualVac = vac_context.isFound("1");
            Assert.AreEqual(expectedVac, actualVac);

            ApplicationDTO application = new ApplicationDTO();
            application.userName = "griddy";
            application.vacancyNumber = "1";
            application.status = "open";

            app_context.presist(application);
            bool expected = true;
            bool actual;
            actual = app_context.isFound("griddy", "1");
            Assert.AreEqual(expected, actual);

            /*Update*/
            application.status = "closed";
            expected = true;
            actual = app_context.merge(application);
            Assert.AreEqual(expected, actual);


            /*Delete*/
            Assert.AreEqual(app_context.removeByUserId("griddy", "1"), true);
            vac_context.removeByUserId("1");
            account_context.removeByUserId("griddy");
            

            
        }
    }
}
