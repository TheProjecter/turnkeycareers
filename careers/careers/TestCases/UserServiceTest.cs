
/* ********************************************************
 * Author: Hughan Kleintes 210036834
 * Date: 5 October 2012
 * Testing Services: 
 *      changeUserApplicationStatus
 *      getShortListedCandidates
 * ********************************************************/

using careers.SERVICES;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;
using careers.SERVICES.Search;

namespace TestCases
{
    /// <summary>
    ///This is a test class for UserServiceTest and is intended
    ///to contain all UserServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserServiceTest
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


        internal virtual UserService CreateUserService()
        {
            // TODO: Instantiate an appropriate concrete class.
            UserService target = new UserServiceImpl();
            return target;
        }

        /// <summary>
        ///A test for getShortListedCandidates
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\careers\\careers", "/")]
        [UrlToTest("http://localhost:12075/")]
        public void userServiceTest()
        {   
            UserService target = CreateUserService(); // TODO: Initialize to an appropriate value
            
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

            ApplicationDTO applicationDto = new ApplicationDTO();
            applicationDto.userName = "griddy";
            applicationDto.vacancyNumber = "1";
            applicationDto.status = ApplicationStatus.APPLIED.ToString();

            app_context.presist(applicationDto);
            bool expected = true;
            bool actual;
            actual = app_context.isFound("griddy", "1");
            Assert.AreEqual(expected, actual);

            //Test changeUserApplicationStatus method
            target.changeUserApplicationStatus("griddy", "1", ApplicationStatus.SHORTLISTED);
            ApplicationDTO applicationDto2 = app_context.find("griddy", "1");
            Assert.AreEqual(ApplicationStatus.SHORTLISTED.ToString(), applicationDto2.status);

            //Test getShortListedCandidates method
            List<ApplicationDTO> candidates = target.getShortListedCandidates("1");
            Assert.AreEqual("griddy", candidates[0].userName);

            /*Delete*/
            Assert.AreEqual(app_context.removeByUserId("griddy", "1"), true);
            Assert.AreEqual(vac_context.removeByUserId("1"), true);
            Assert.AreEqual(account_context.removeByUserId("griddy"), true);
            
        }
    }
}
