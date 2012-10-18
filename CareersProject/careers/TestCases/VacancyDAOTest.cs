using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class VacancyDAOTest
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
        public void VacancyDAOConstructorTest()
        {
            /*Context*/
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

            /*Update*/
            vac.status = "draft";
            vac_context.merge(vac);

            Assert.AreEqual(vac.status, "draft");

            /*Delete*/
            Assert.AreEqual(vac_context.removeByUserId("1"), true);
            vac_context.removeByUserId("1");
        }
    }
}
