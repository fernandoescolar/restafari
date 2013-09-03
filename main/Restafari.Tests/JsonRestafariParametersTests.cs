using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class JsonRestafariParametersTests : RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";

        public JsonRestafariParametersTests()
            : base(TestRequestFactory.Instance)
        {
        }

        [TestMethod]
        public void JsonBodyIntParamaterTest()
        {
            this.Post(FakeUrl, 12);

            Assert.AreEqual("12", TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void JsonBodyIntParamatersTest()
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

            this.Post(FakeUrl, "ola k ase");

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void JsonBodyStringParamatersTest()
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

            this.Post(FakeUrl, dto);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void JsonBodyComplexParamatersTest()
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
        public async Task JsonBodyIntParamaterAsyncTest()
        {
            await this.PostAsync(FakeUrl, 12);

            Assert.AreEqual("12", TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public async Task JsonBodyIntParamatersAsyncTest()
        {
            var parameters = new Parameters { { string.Empty, 12 } };

            await this.PostAsync(FakeUrl, parameters);

            Assert.AreEqual("12", TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public async Task JsonBodyTwoIntParamatersAsyncTest()
        {
            const string expected = @"{""param1"":12,""param2"":13}";
            var parameters = new Parameters { { "param1", 12 }, { "param2", 13 } };

            await this.PostAsync(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public async Task JsonBodyStringParamaterAsyncTest()
        {
            const string expected = @"""ola k ase""";

            await this.PostAsync(FakeUrl, "ola k ase");

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public async Task JsonBodyStringParamatersAsyncTest()
        {
            const string expected = @"""ola k ase""";
            var parameters = new Parameters { { string.Empty, "ola k ase" } };

            await this.PostAsync(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public async Task JsonBodyTwoStringAndIntParamatersAsyncTest()
        {
            const string expected = @"{""param1"":""ola k ase"",""param2"":13}";
            var parameters = new Parameters { { "param1", "ola k ase" }, { "param2", 13 } };

            await this.PostAsync(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public async Task JsonBodyComplexParamaterAsyncTest()
        {
            const string expected = @"{""id"":""fef2511d-601e-4061-8201-a6352fa898b4"",""name"":""fulano"",""age"":30,""active"":true}";
            var dto = new DummyDataTransferObject
            {
                Id = new Guid("FEF2511D-601E-4061-8201-A6352FA898B4"),
                Active = true,
                Age = 30,
                Name = "fulano"
            };

            await this.PostAsync(FakeUrl, dto);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public async Task JsonBodyComplexParamatersAsyncTest()
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

            await this.PostAsync(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public async Task JsonBodyTwoComplexAndIntParamatersAsyncTest()
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

            await this.PostAsync(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            TestRequestFactory.Request.CleanUp();
        }
    }
}
