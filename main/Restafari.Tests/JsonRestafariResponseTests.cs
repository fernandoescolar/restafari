using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class JsonRestafariResponseTests : RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";

        public JsonRestafariResponseTests()
            : base(TestRequestFactory.Instance)
        {
        }

        [TestMethod]
        public void JsonResponseIntTest()
        {
            TestRequestFactory.Response.WriteInStream("12");
            var actual = this.Post<int>(FakeUrl);

            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void JsonResponseStringTest()
        {
            TestRequestFactory.Response.WriteInStream(@"""ola k ase""");
            var actual = this.Post<string>(FakeUrl);

            Assert.AreEqual("ola k ase", actual);
        }

        [TestMethod]
        public void JsonResponseGuidTest()
        {
            TestRequestFactory.Response.WriteInStream(@"""A60049B5-2D2E-4CF5-9173-C249D1EE1818""");
            var expected = new Guid("A60049B5-2D2E-4CF5-9173-C249D1EE1818");
            var actual = this.Post<Guid>(FakeUrl);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JsonResponseComplexTypeTest()
        {
            var expected = new DummyDataTransferObject
            {
                Id = new Guid("FEF2511D-601E-4061-8201-A6352FA898B4"),
                Active = true,
                Age = 30,
                Name = "fulano"
            };
            TestRequestFactory.Response.WriteInStream(@"{""id"":""fef2511d-601e-4061-8201-a6352fa898b4"",""name"":""fulano"",""age"":30,""active"":true}");
            var actual = this.Post<DummyDataTransferObject>(FakeUrl);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JsonResponseComplexTypeListTest()
        {
            var dummy = new DummyDataTransferObject
            {
                Id = new Guid("FEF2511D-601E-4061-8201-A6352FA898B4"),
                Active = true,
                Age = 30,
                Name = "fulano"
            };
            var expected = new List<DummyDataTransferObject> { dummy, dummy };
            TestRequestFactory.Response.WriteInStream(@"[{""id"":""fef2511d-601e-4061-8201-a6352fa898b4"",""name"":""fulano"",""age"":30,""active"":true},{""id"":""fef2511d-601e-4061-8201-a6352fa898b4"",""name"":""fulano"",""age"":30,""active"":true}]");
            var actual = this.PostList<DummyDataTransferObject>(FakeUrl).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task JsonResponseIntAsyncTest()
        {
            TestRequestFactory.Response.WriteInStream("12");
            var actual = await this.PostAsync<int>(FakeUrl);

            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public async Task JsonResponseStringAsyncTest()
        {
            TestRequestFactory.Response.WriteInStream(@"""ola k ase""");
            var actual = await this.PostAsync<string>(FakeUrl);

            Assert.AreEqual("ola k ase", actual);
        }

        [TestMethod]
        public async Task JsonResponseGuidAsyncTest()
        {
            TestRequestFactory.Response.WriteInStream(@"""A60049B5-2D2E-4CF5-9173-C249D1EE1818""");
            var expected = new Guid("A60049B5-2D2E-4CF5-9173-C249D1EE1818");
            var actual = await this.PostAsync<Guid>(FakeUrl);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task JsonResponseComplexAsyncTypeTest()
        {
            var expected = new DummyDataTransferObject
            {
                Id = new Guid("FEF2511D-601E-4061-8201-A6352FA898B4"),
                Active = true,
                Age = 30,
                Name = "fulano"
            };
            TestRequestFactory.Response.WriteInStream(@"{""id"":""fef2511d-601e-4061-8201-a6352fa898b4"",""name"":""fulano"",""age"":30,""active"":true}");
            var actual = await this.PostAsync<DummyDataTransferObject>(FakeUrl);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task JsonResponseComplexTypeListAsyncTest()
        {
            var dummy = new DummyDataTransferObject
            {
                Id = new Guid("FEF2511D-601E-4061-8201-A6352FA898B4"),
                Active = true,
                Age = 30,
                Name = "fulano"
            };
            var expected = new List<DummyDataTransferObject> { dummy, dummy };
            TestRequestFactory.Response.WriteInStream(@"[{""id"":""fef2511d-601e-4061-8201-a6352fa898b4"",""name"":""fulano"",""age"":30,""active"":true},{""id"":""fef2511d-601e-4061-8201-a6352fa898b4"",""name"":""fulano"",""age"":30,""active"":true}]");
            var actual = (await this.PostListAsync<DummyDataTransferObject>(FakeUrl)).ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            TestRequestFactory.Request.CleanUp();
            TestRequestFactory.Response.CleanUp();
        }
    }
}
