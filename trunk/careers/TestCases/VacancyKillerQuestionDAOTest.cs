using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for VacancyKillerQuestionDAOTest and is intended
    ///to contain all VacancyKillerQuestionDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VacancyKillerQuestionDAOTest
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
        public void VacancyKillerQuestionDAO_Test()
        {
            /*Context*/
            VacancyKillerQuestionDAO vacKill_context = new VacancyKillerQuestionDAO();
            VacancyDAO vac_context = new VacancyDAO();

            /*Insert*/
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

            VacancyKillerQuestionDTO vacKill = new VacancyKillerQuestionDTO();
            vacKill.vacancyNumber = "1";
            vacKill.question = "Do you have a BTech";
            vacKill.answer = "Yes";

            Assert.AreEqual(vacKill_context.presist(vacKill),true);

            /*Update*/
            vacKill.answer = "No";
            vacKill_context.merge(vacKill);
            Assert.AreEqual(vacKill.answer, "No");

            /*Delete*/
            Assert.AreEqual(vacKill_context.removeByUserId("Do you have a BTech","1"),true );
            vac_context.removeByUserId("1");
        }
    }
}
