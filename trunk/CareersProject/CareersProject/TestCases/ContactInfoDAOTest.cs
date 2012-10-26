using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class ContactInfoDAOTest
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
        public void ContactInfoDAOConstructorTest()
        {
            /*Context*/
            ContactInfoDAO contactInfo_context = new ContactInfoDAO();
            AccountDAO acc_context = new AccountDAO();
            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "john";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            ContactInfoDTO contact = new ContactInfoDTO();
            contact.userName = "john";
            contact.contactType = "skype";
            contact.data = "skippy";


            contactInfo_context.presist(contact);

            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            actual = contactInfo_context.isFound("john", "skype");
            Assert.AreEqual(expected, actual);

            /*Update*/
            contact.data = "Gready";
            contactInfo_context.merge(contact);

            string expectedUpdate = "Gready";
            ContactInfoDTO contUpd = contactInfo_context.find("john", "skype");
            Assert.AreEqual(expectedUpdate, contUpd.data);

            /*Delete*/
            contactInfo_context.removeByUserId("john", "skype");

            bool expectedDelete = false;
            bool actualDelete = contactInfo_context.isFound("john", "skype");
            Assert.AreEqual(expectedDelete, actualDelete);

            acc_context.removeByUserId("john");
        }
    }
}
