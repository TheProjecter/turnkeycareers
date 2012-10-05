using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for LanguageDAOTest and is intended
    ///to contain all LanguageDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LanguageDAOTest
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
        /*[HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\careers\\careers", "/")]*/
        [UrlToTest("http://localhost:12075/")]
        public void LanguageDAO_Test()
        {
            LanguageDAO lang_context = new LanguageDAO(); 
            AccountDAO acc_context = new AccountDAO();

            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "griddy";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            LanguageDTO lang = new LanguageDTO();
            lang.userName = "griddy";
            lang.languageName = "english";
            lang.speak = "no";
            lang.write = "Yes";
            lang.reads = "Yes";

            lang_context.presist(lang);
            Assert.AreEqual("no", lang_context.find("griddy", "english").speak);

            /*Update*/ 
            /*lang.speak = "X";
            lang_context.merge(lang);
            string str = lang_context.find("griddy", "english").speak;
            //Assert.AreEqual("X", str);

            /*Delete*/
            lang_context.removeByUserId("griddy", "english");
            Assert.AreEqual(false, lang_context.isFound("griddy", "english"));
            
            acc_context.removeByUserId("griddy");
            
        }
    }
}
