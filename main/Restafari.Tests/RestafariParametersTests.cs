using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class RestafariParametersTests : RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";

        public RestafariParametersTests()
            : base(TestRequestFactory.Instance)
        {
        }

        [TestMethod]
        public void JsonBodyIntParamaterTest()
        {
            var parameters = new Parameters { { string.Empty, 12 } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual("12", TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void JsonBodyTwoIntParamatersTest()
        {
            const string expected = @"{""param1"":12,""param2"":13}";
            var parameters = new Parameters { { "param1", 12 }, { "param2", 13 } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void JsonBodyStringParamaterTest()
        {
            const string expected = @"""ola k ase""";
            var parameters = new Parameters { { string.Empty, "ola k ase" } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void JsonBodyTwoStringAndIntParamatersTest()
        {
            const string expected = @"{""param1"":""ola k ase"",""param2"":13}";
            var parameters = new Parameters { { "param1", "ola k ase" }, { "param2", 13 } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void JsonBodyComplexParamaterTest()
        {
            const string expected = @"{""id"":""fef2511d-601e-4061-8201-a6352fa898b4"",""name"":""fulano"",""age"":30,""active"":true}";
            var dto = new DummyDataTransferObject
            {
                Id = new Guid("FEF2511D-601E-4061-8201-A6352FA898B4"),
                Active = true,
                Age = 30,
                Name = "fulano"
            };

            var parameters = new Parameters { { string.Empty, dto } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void JsonBodyTwoComplexAndIntParamatersTest()
        {
            const string expected = @"{""param1"":{""id"":""fef2511d-601e-4061-8201-a6352fa898b4"",""name"":""fulano"",""age"":30,""active"":true},""param2"":13}";
            var dto = new DummyDataTransferObject
            {
                Id = new Guid("FEF2511D-601E-4061-8201-A6352FA898B4"),
                Active = true,
                Age = 30,
                Name = "fulano"
            };
            var parameters = new Parameters { { "param1", dto }, { "param2", 13 } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
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

        [TestCleanup]
        public void TestCleanUp()
        {
            TestRequestFactory.Request.CleanUp();
        }
    }
}
