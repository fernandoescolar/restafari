using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class XmlRestafariParametersTests : RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";

        public XmlRestafariParametersTests()
            : base(TestRequestFactory.Instance)
        {
            this.ContentType = ContentType.Xml;
        }

        [TestMethod]
        public void XmlBodyIntParamaterTest()
        {
            const string expected = "<int xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">12</int>";
            this.Post(FakeUrl, 12);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void XmlBodyIntParamatersTest()
        {
            const string expected = "<int xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">12</int>";
            var parameters = new Parameters { { string.Empty, 12 } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void XmlBodyTwoIntParamatersTest()
        {
            var parameters = new Parameters { { "param1", 12 }, { "param2", 13 } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual(string.Empty, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void XmlBodyStringParamaterTest()
        {
            const string expected = "<string xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">ola k ase</string>";

            this.Post(FakeUrl, "ola k ase");

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void XmlBodyStringParamatersTest()
        {
            const string expected = "<string xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">ola k ase</string>";
            var parameters = new Parameters { { string.Empty, "ola k ase" } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual(expected, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void XmlBodyTwoStringAndIntParamatersTest()
        {
            var parameters = new Parameters { { "param1", "ola k ase" }, { "param2", 13 } };

            this.Post(FakeUrl, parameters);

            Assert.AreEqual(string.Empty, TestRequestFactory.Request.Buffer);
        }

        [TestMethod]
        public void XmlBodyComplexParamaterTest()
        {
            const string expected = "<DummyDataTransferObject xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/Restafari.Tests.Mocks\"><active>true</active><age>30</age><id>fef2511d-601e-4061-8201-a6352fa898b4</id><name>fulano</name></DummyDataTransferObject>";
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
        public void XmlBodyComplexParamatersTest()
        {
            const string expected = "<DummyDataTransferObject xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/Restafari.Tests.Mocks\"><active>true</active><age>30</age><id>fef2511d-601e-4061-8201-a6352fa898b4</id><name>fulano</name></DummyDataTransferObject>";
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

        [TestCleanup]
        public void TestCleanUp()
        {
            TestRequestFactory.Request.CleanUp();
        }
    }
}