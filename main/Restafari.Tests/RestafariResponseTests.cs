using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class RestafariResponseTests : RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";

        public RestafariResponseTests()
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

        [TestCleanup]
        public void TestCleanUp()
        {
            TestRequestFactory.Request.CleanUp();
            TestRequestFactory.Response.CleanUp();
        }
    }
}
