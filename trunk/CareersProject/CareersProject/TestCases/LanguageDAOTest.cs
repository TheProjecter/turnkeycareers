﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class LanguageDAOTest
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
        public void LanguageDAOConstructorTest()
        {
            /*Context*/
            LanguageDAO lang_context = new LanguageDAO();
            AccountDAO acc_context = new AccountDAO();

            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "john";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            LanguageDTO lang = new LanguageDTO();
            lang.userName = "john";
            lang.languageName = "english";
            lang.speak = "Yes";
            lang.write = "Yes";
            lang.reads = "Yes";

            lang_context.presist(lang);
            Assert.AreEqual(lang.speak, lang_context.find("john", "english").speak);

            /*Update*/
            lang.speak = "No";
            lang_context.merge(lang);
            Assert.AreEqual("No", lang_context.find("john", "english").speak);

            /*Delete*/
            lang_context.removeByUserId("john", "english");
            Assert.AreEqual(lang_context.isFound("john", "english"), false);

            acc_context.removeByUserId("john");
        }
    }
}
