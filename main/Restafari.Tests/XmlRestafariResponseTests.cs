using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class XmlRestafariResponseTests : RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";

        public XmlRestafariResponseTests()
            : base(TestRequestFactory.Instance)
        {
            this.ContentType = ContentType.Xml;
        }

        [TestMethod]
        public void XmlResponseIntTest()
        {
            TestRequestFactory.Response.WriteInStream("<int xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">12</int>");
            var actual = this.Post<int>(FakeUrl);

            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void XmlResponseStringTest()
        {
            TestRequestFactory.Response.WriteInStream("<string xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">ola k ase</string>");
            var actual = this.Post<string>(FakeUrl);

            Assert.AreEqual("ola k ase", actual);
        }

        [TestMethod]
        public void XmlResponseGuidTest()
        {
            TestRequestFactory.Response.WriteInStream("<guid xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">A60049B5-2D2E-4CF5-9173-C249D1EE1818</guid>");
            var expected = new Guid("A60049B5-2D2E-4CF5-9173-C249D1EE1818");
            var actual = this.Post<Guid>(FakeUrl);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XmlResponseComplexTypeTest()
        {
            var expected = new DummyDataTransferObject
            {
                Id = new Guid("FEF2511D-601E-4061-8201-A6352FA898B4"),
                Active = true,
                Age = 30,
                Name = "fulano"
            };
            TestRequestFactory.Response.WriteInStream("<DummyDataTransferObject xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/Restafari.Tests.Mocks\"><active>true</active><age>30</age><id>fef2511d-601e-4061-8201-a6352fa898b4</id><name>fulano</name></DummyDataTransferObject>");
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