using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for HigherEducationDAOTest and is intended
    ///to contain all HigherEducationDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HigherEducationDAOTest
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
        public void HigherEducation_Test()
        {
            /*Context*/
            HigherEducationDAO higher_context = new HigherEducationDAO();      
            AccountDAO account_context = new AccountDAO();

            /*Insert*/
            AccountDTO account = new AccountDTO();
            account.userName = "griddy";
            account.status = "active";
            account.password = "greddy";
            account.accountType = "admin";

            account_context.presist(account);

            HigherEducationDTO higherEdu = new HigherEducationDTO();
            higherEdu.userName = "griddy";
            higherEdu.country = "SA";
            higherEdu.educationType = "BTECH";
            higherEdu.industry = "Information Technology";
            higherEdu.institution = "CPUT";
            higherEdu.length = "four years";
            higherEdu.major = "Technical Programming";
            higherEdu.nqf = "7";
            higherEdu.province = "WP";
            higherEdu.town = "Cape Town";
            
            higher_context.presist(higherEdu);      
            
            bool expected = true;
            bool actual;
            actual = higher_context.isFound("griddy", "Technical Programming");
            Assert.AreEqual(expected, actual);

            /*Update*/
            higherEdu.institution = "UWC";
            higher_context.merge(higherEdu);

            string expectedUpdate = "UWC";
            HigherEducationDTO contUpd = higher_context.find("griddy", "Technical Programming");
            Assert.AreEqual(expectedUpdate, contUpd.institution);

            /*Delete*/
            higher_context.removeByUserId("griddy", "Technical Programming");
            bool expectedDelete = false;
            bool actualDelete = higher_context.isFound("griddy", "Technical Programming");
            Assert.AreEqual(expectedDelete, actualDelete);

            account_context.removeByUserId("griddy");
            
        }
    }
}
