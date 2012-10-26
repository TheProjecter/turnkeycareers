using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class SupportDocDAOTest
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
        public void SupportDocDAOConstructorTest()
        {
            /*context*/
            SupportDocDAO sup_context = new SupportDocDAO(); // TODO: Initialize to an appropriate value
            AccountDAO acc_context = new AccountDAO();
            /*insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "john";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            SupportDocDTO supp = new SupportDocDTO();
            supp.userName = "john";
            byte[] bits = { 1, 0, 1, 0, 0, 1 };
            supp.content = bits;
            supp.description = "Supporting doc";
            supp.title = "help";

            sup_context.presist(supp);
            Assert.AreEqual(supp.title, sup_context.find("john", "help").title);
            /*Update*/
            supp.description = "NEW doc";
            sup_context.merge(supp);
            Assert.AreEqual("NEW doc", sup_context.find("john", "help").description);

            /*Delete*/
            sup_context.removeByUserId("john", "help");
            Assert.AreEqual(sup_context.isFound("john", "help"), false);
            acc_context.removeByUserId("john");
        }
    }
}
