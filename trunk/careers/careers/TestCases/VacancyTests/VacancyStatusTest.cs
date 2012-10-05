using careers.SERVICES.VacancyServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for VacancyStatusTest and is intended
    ///to contain all VacancyStatusTest Unit Tests
    ///</summary>
    [TestClass()]
    public class VacancyStatusTest
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
        ///A test for getVacanciesByStatus
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [UrlToTest("http://localhost:12075/")]
        public void getVacanciesByStatusTest()
        {
            VacancyStatus target = new VacancyStatus();

            VacancyDAO vac_context = new VacancyDAO();
            VacancyDTO vac = new VacancyDTO();
            vac.department = "IS";
            vac.description = "Web services";
            vac.manager = "Tom";
            vac.recruiter = "Thumi";
            vac.site = "www.petrosa.co.za";
            vac.startDate = new DateTime(2012, 10, 10);
            vac.endDate = new DateTime(2012, 12, 15);
            vac.description = "desktop support";
            vac.title = "support technician";
            vac.vacancyNumber = "1";
            vac.viewCount = 10;
            vac.viewStatus = "published";
            vac.status = "active";

            vac_context.presist(vac);

            bool expected = true;
            bool actual;
            actual = vac_context.isFound("1");
            Assert.AreEqual(expected, actual);

            VacancyDTO vacTwo = new VacancyDTO();
            vacTwo.department = "Business";
            vacTwo.description = "Money";
            vacTwo.manager = "Marc";
            vacTwo.recruiter = "Mandy";
            vacTwo.site = "Durban";
            vacTwo.startDate = new DateTime(2012, 1, 10);
            vacTwo.endDate = new DateTime(2012, 3, 15);
            vacTwo.description = "desktop support";
            vacTwo.title = "support technician";
            vacTwo.vacancyNumber = "2";
            vacTwo.viewCount = 10;
            vacTwo.viewStatus = "published";
            vacTwo.status = "active";

            vac_context.presist(vacTwo);

            bool expected2 = true;
            bool actual2;
            actual2 = vac_context.isFound("2");
            Assert.AreEqual(expected2, actual2);

            VacancyDTO vacThree = new VacancyDTO();
            vacThree.department = "IS";
            vacThree.description = "Money";
            vacThree.manager = "Tom";
            vacThree.recruiter = "Fuji";
            vacThree.site = "Durban";
            vacThree.startDate = new DateTime(2012, 11, 10);
            vacThree.endDate = new DateTime(2012, 12, 20);
            vacThree.description = "App Specialist";
            vacThree.title = "Developer";
            vacThree.vacancyNumber = "3";
            vacThree.viewCount = 10;
            vacThree.viewStatus = "published";
            vacThree.status = "inactive";

            vac_context.presist(vacThree);

            bool expected3 = true;
            bool actual3;
            actual3 = vac_context.isFound("3");
            Assert.AreEqual(expected3, actual3);

            VacancyStatus status = new VacancyStatus();

            List<VacancyDTO> listVacs = status.getVacanciesByStatus("active");

            foreach (VacancyDTO v in listVacs) 
            {
                string vacNo = v.vacancyNumber.ToString();
                Assert.IsNotNull(vacNo);

            }
             
            vac_context.removeByUserId("1");
            vac_context.removeByUserId("2");
            vac_context.removeByUserId("3");
        }
    }
}
