using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class BasicEduSubjectDAOTest
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
        public void BasicEduSubjectDAOConstructorTest()
        {
            /*Context*/
            BasicEduSubjectDAO basicEdu_context = new BasicEduSubjectDAO();
            BasicEduDAO edu_context = new BasicEduDAO();
            AccountDAO acc_context = new AccountDAO();

            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "griddy";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            BasicEduDTO basic_Edu = new BasicEduDTO();
            basic_Edu.userName = "griddy";
            basic_Edu.country = "South Africa";
            basic_Edu.levelCompleted = 12;
            basic_Edu.province = "WP";
            basic_Edu.school = "Brackenfell High School";
            basic_Edu.town = "Cape Town";

            edu_context.presist(basic_Edu);

            BasicEduSubjectDTO basicEduSub = new BasicEduSubjectDTO();
            basicEduSub.subjectName = "Technical Programming";
            basicEduSub.subjectDescription = "Mr Kabaso is Awesome";
            basicEduSub.userName = "griddy";

            basicEdu_context.presist(basicEduSub);

            /*Update*/
            basicEduSub.subjectDescription = "Mr Kabaso is Awesome!";
            basicEdu_context.merge(basicEduSub);


            string expectedUpdate = "Mr Kabaso is Awesome!";
            BasicEduSubjectDTO updateEduSub = basicEdu_context.find("griddy", "Technical Programming");
            Assert.AreEqual(expectedUpdate, updateEduSub.subjectDescription);


            /*Delete*/
            basicEdu_context.removeByUserId("griddy", "Technical Programming");
            bool expectedDelBasicEduSub = false;
            bool actualDelBasicEduSub = basicEdu_context.isFound("griddy", "Technical Programming");
            Assert.AreEqual(expectedDelBasicEduSub, actualDelBasicEduSub);
            edu_context.removeByUserId("griddy");
            acc_context.removeByUserId("griddy");
        }
    }
}
