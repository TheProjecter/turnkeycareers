/*******************************
Developer: WA Pretoruis
Student  : 205093280
*******************************/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestCases
{
    
    
    /// <summary>
    ///This is a test class for UserDAOTest and is intended
    ///to contain all UserDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserDAOTest
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
        [AspNetDevelopmentServerHost("C:\\careers\\careers", "/")]
        [UrlToTest("http://localhost:12075/")]
        public void UserDAO_Test()
        {
            
            /*Context*/
            AccountDAO acc_context = new AccountDAO();
            UserDAO user_context = new UserDAO();
            /*Insert*/
            AccountDTO acc = new AccountDTO();
            acc.userName = "griddy";
            acc.password = "grid";
            acc.accountType = "administrator";
            acc.status = "active";

            acc_context.presist(acc);

            UserDTO user = new UserDTO();
            user.basicEducation = true;
            user.citizenship = true;
            user.disabled = true;
            user.employed = true;
            user.employmentHistory = true;
            user.fullName = "Andre";
            user.gender = "male";
            user.higherEducation = true;
            user.id = "8630302930";
            user.idType = "SA";
            user.language = true;
            user.license = true;
            user.nickName = "WIlliem";
            user.postalAddress = true;
            user.race = "white";
            user.residentialAddress = true;
            user.surname = "Pretorious";
            user.userName = "griddy";

          //  user_context.presist(user);
            //Assert.AreEqual(user.race, user_context.find("griddy","8630302930").race);

            ///*Update*/
            //user.nickName = "willi";
            //user_context.merge(user);
            //Assert.AreEqual(user.nickName, user_context.find("griddy", "8630302930").nickName);

            ///*Delete*/
            //user_context.removeByUserId("griddy", "8630302930");
            //Assert.AreEqual(user_context.isFound("griddy", "8630302930"), false);

            acc_context.removeByUserId("griddy");

        }
    }
}
