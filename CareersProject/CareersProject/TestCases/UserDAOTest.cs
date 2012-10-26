using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{


    [TestClass()]
    public class UserDAOTest
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
        public void UserDAOConstructorTest()
        {
            /*Context*/
            AccountDAO acc_context = new AccountDAO();
            UserDAO user_context = new UserDAO();
            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "john";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            UserDTO user = new UserDTO();
            user.id = "8630302930";
            user.userName = "john";
            user.fullName = "Andre";
            user.nickName = "WIlliem";
            user.surname = "Pretorius";
            user.gender = "male";
            user.race = "white";
            user.basicEducation = true;
            user.citizenship = true;
            user.disabled = true;
            user.employed = true;
            user.employmentHistory = true;
            user.higherEducation = true;
            user.idType = "SA";
            user.language = true;
            user.license = true;
            user.postalAddress = true;
            user.residentialAddress = true;



            user_context.presist(user);
            Assert.AreEqual(true,user_context.isFound("john") );

            ///*Update*/
            user.nickName = "willi";
            user_context.merge(user);
            Assert.AreEqual(user.nickName, user_context.find("john").nickName);

            ///*Delete*/
            user_context.removeByUserId("john");
            Assert.AreEqual(user_context.isFound("john"), false);

            acc_context.removeByUserId("john");

        }
    }
}
