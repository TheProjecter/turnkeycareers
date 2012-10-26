﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class BasicEduDAOTest
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
        public void BasicEduDAOConstructorTest()
        {
            /*Context*/
            BasicEduDAO edu_context = new BasicEduDAO();
            AccountDAO acc_context = new AccountDAO();

            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "john";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            BasicEduDTO basic_Edu = new BasicEduDTO();
            basic_Edu.userName = "john";
            basic_Edu.country = "South Africa";
            basic_Edu.levelCompleted = 12;
            basic_Edu.province = "WP";
            basic_Edu.school = "Brackenfell High School";
            basic_Edu.town = "Cape Town";

            edu_context.presist(basic_Edu);


            /*Update*/
            basic_Edu.province = "PE";
            edu_context.merge(basic_Edu);

            string expectedUpdate = "PE";
            BasicEduDTO updateEdu = edu_context.find("john");
            Assert.AreEqual(expectedUpdate, updateEdu.province);


            ///*Delete*/
            edu_context.removeByUserId("john");
            bool expectedDelBasicEdu = false;
            bool actualDelBasicEdu = edu_context.isFound("john");
            Assert.AreEqual(expectedDelBasicEdu, actualDelBasicEdu);

            acc_context.removeByUserId("john");
        }
    }
}
