using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class QueryStringRestafariParametersTests : RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";

        public QueryStringRestafariParametersTests()
            : base(TestRequestFactory.Instance)
        {
        }

        [TestMethod]
        public void QueryStringIntParamaterTest()
        {
            var expected = string.Format("{0}{1}", FakeUrl, "?param1=12");
            var parameters = new Parameters { { "param1", 12 } };

            this.Get(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Url);
        }

        [TestMethod]
        public void QueryStringTwoIntParamatersTest()
        {
            var expected = string.Format("{0}{1}", FakeUrl, "?param1=12&param2=13");
            var parameters = new Parameters { { "param1", 12 }, { "param2", 13 } };

            this.Get(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Url);
        }

        [TestMethod]
        public void QueryStringStringParamaterTest()
        {
            var expected = string.Format("{0}{1}", FakeUrl, "?param1=ola k ase");
            var parameters = new Parameters { { "param1", "ola k ase" } };

            this.Get(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Url);
        }

        [TestMethod]
        public void QueryStringTwoStringAndIntParamatersTest()
        {
            var expected = string.Format("{0}{1}", FakeUrl, "?param1=ola k ase&param2=13");
            var parameters = new Parameters { { "param1", "ola k ase" }, { "param2", 13 } };

            this.Get(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Url);
        }
    }
}