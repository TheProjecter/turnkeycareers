
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 4 October 2012
 * Testing Services:
 *      getApplicationByUsername 
 *      getApplicationByStatus 
 *      getApplicationByVacancyNumber 
 * ********************************************************/

using careers.SERVICES.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for ApplicationSearchServiceTest and is intended
    ///to contain all ApplicationSearchServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ApplicationSearchServiceTest
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
        ///A test for getApplicationByUsername
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\careers\\careers", "/")]
        [UrlToTest("http://localhost:12075/")]
        public void applicationSearchServiceTest()
        {
            ApplicationSearchService target = new ApplicationSearchServiceImpl(); // TODO: Initialize to an appropriate value

            AccountDAO account_context = new AccountDAO();
            ApplicationDAO app_context = new ApplicationDAO();
            VacancyDAO vac_context = new VacancyDAO();

            /*Insert*/
            AccountDTO account = new AccountDTO();
            account.userName = "graddy";
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
            application.userName = "graddy";
            application.vacancyNumber = "1";
            application.status = "open";            
            app_context.presist(application);

            //Test getApplicationByUsername method
            List<ApplicationDTO> applicationTestListObj = target.getApplicationByUsername("graddy");
            Assert.AreEqual(application.status, applicationTestListObj[0].status);

            //Test getApplicationByStatus method
            List<ApplicationDTO> applicationTestListObj2 = target.getApplicationByStatus("open");
            Assert.AreEqual(application.status, applicationTestListObj2[0].status);

            //Test getApplicationByVacancyNumber method
            List<ApplicationDTO> applicationTestListObj3 = target.getApplicationByVacancyNumber("1");
            Assert.AreEqual(application.status, applicationTestListObj3[0].status);
            
            /*Delete*/
            /*
            account_context.removeByUserId("graddy");
            bool expectedDelete = false;
            bool actualDelete = account_context.isFound("graddy");
            Assert.AreEqual(expectedDelete, actualDelete);
            */
        }

    }
}
