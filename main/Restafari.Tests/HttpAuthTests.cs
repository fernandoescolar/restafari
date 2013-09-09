using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class HttpAuthTests : RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";
        private const string User = "myUser";
        private const string Password = "myUser";

        public HttpAuthTests() : base(User, Password, TestRequestFactory.Instance)
        {
        }

        [TestMethod]
        public void GlobalUserAndPasswordTest()
        {
            this.Get(FakeUrl);

            var credentials = TestRequestFactory.Request.Credentials as NetworkCredential;
            Assert.AreEqual(credentials.UserName, User);
            Assert.AreEqual(credentials.Password, Password);
        }

        [TestMethod]
        public void CustomUserAndPasswordTest()
        {
            const string user = "myUser2";
            const string password = "myPassword2";

            this.Get(new RequestSettings
                         {
                             Url = FakeUrl,
                             User = user,
                             Password = password
                         });

            var credentials = TestRequestFactory.Request.Credentials as NetworkCredential;
            Assert.AreEqual(credentials.UserName, user);
            Assert.AreEqual(credentials.Password, password);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            TestRequestFactory.Request.CleanUp();
            TestRequestFactory.Response.CleanUp();
        }
    }
}
