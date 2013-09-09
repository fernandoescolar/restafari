using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class RequestSettingsTests : RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";

        public RequestSettingsTests()
            : base(TestRequestFactory.Instance)
        {
        }

        [TestMethod]
        public void DefaultGlobalContentTypeJsonGetTest()
        {
            TestRequestFactory.Request.ContentType = string.Empty;
            this.Get(FakeUrl);
            
            Assert.AreEqual(TestRequestFactory.Request.ContentType, string.Empty);
            Assert.AreEqual(TestRequestFactory.Request.Accept, "application/json");
        }

        [TestMethod]
        public void GlobalContentTypeXmlGetTest()
        {
            TestRequestFactory.Request.ContentType = string.Empty;
            this.ContentType = ContentType.Xml;
            this.Get(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.ContentType, string.Empty);
            Assert.AreEqual(TestRequestFactory.Request.Accept, "application/xml");
        }

        [TestMethod]
        public void DefaultGlobalContentTypeJsonPostTest()
        {
            this.Post(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.ContentType, "application/json; charset=UTF-8");
            Assert.AreEqual(TestRequestFactory.Request.Accept, "application/json");
        }

        [TestMethod]
        public void GlobalContentTypeXmlPostTest()
        {
            this.ContentType = ContentType.Xml;
            this.Post(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.ContentType, "application/xml; charset=UTF-8");
            Assert.AreEqual(TestRequestFactory.Request.Accept, "application/xml");
        }

        [TestMethod]
        public void CustomContentTypeJsonTest()
        {
            this.ContentType = ContentType.Xml;
            this.Put(new RequestSettings
                         {
                             Url = FakeUrl,
                             ContentType = ContentType.Json
                         });

            Assert.AreEqual(TestRequestFactory.Request.ContentType, "application/json; charset=UTF-8");
            Assert.AreEqual(TestRequestFactory.Request.Accept, "application/json");
        }

        [TestMethod]
        public void CustomContentTypeXmlTest()
        {
            this.Put(new RequestSettings
            {
                Url = FakeUrl,
                ContentType = ContentType.Xml
            });

            Assert.AreEqual(TestRequestFactory.Request.ContentType, "application/xml; charset=UTF-8");
            Assert.AreEqual(TestRequestFactory.Request.Accept, "application/xml");
        }

        [TestMethod]
        public void CustomRequestDecoratorTest()
        {
            var decorator = new TestRequestDecorator();
            this.Put(new RequestSettings
            {
                Url = FakeUrl,
                RequestDecorator = decorator
            });

            Assert.AreEqual(TestRequestFactory.Request.ContentType, TestRequestDecorator.ContentTypeText);
            Assert.AreEqual(TestRequestFactory.Request.Accept, TestRequestDecorator.AcceptText);
            Assert.IsTrue(decorator.Visited);
        }

        [TestMethod]
        public void CustomSerializerTest()
        {
            var serializer = new TestSerializer();
            this.Put(new RequestSettings
            {
                Url = FakeUrl,
                Parameters = new Parameters(12),
                SerializationStrategy = serializer
            });

            Assert.IsTrue(serializer.Visited);
            Assert.IsTrue(serializer.CanVisited);
        }

        [TestMethod]
        public void CustomDeserializerTest()
        {
            var deserializer = new TestDeserializer();
            this.Put<int>(new RequestSettings
            {
                Url = FakeUrl,
                DeserializationStrategy = deserializer
            });

            Assert.IsTrue(deserializer.Visited);
        }

        [TestMethod]
        public void CustomRequestCreatedHandlerTest()
        {
            var visited = false;
            this.Put(new RequestSettings
            {
                Url = FakeUrl,
                RequestCreated = (o, r) => visited = true
            });

            Assert.IsTrue(visited);
            Assert.IsTrue(RequestCreatedVisited);
        }

        [TestMethod]
        public void CustomResponseReceivedHandlerTest()
        {
            var visited = false;
            this.Put(new RequestSettings
            {
                Url = FakeUrl,
                ResponseReceived = (o, r) => visited = true
            });

            Assert.IsTrue(visited);
            Assert.IsTrue(ResponseReceivedVisited);
        }

        [TestMethod]
        public void GlobalRequestCreatedHandlerTest()
        {
            this.Put(FakeUrl);

            Assert.IsTrue(RequestCreatedVisited);
        }

        [TestMethod]
        public void GlobalResponseReceivedHandlerTest()
        {
            var visited = false;
            this.Put(FakeUrl);

            Assert.IsTrue(ResponseReceivedVisited);
        }

        protected bool RequestCreatedVisited { get; set; }

        protected bool ResponseReceivedVisited { get; set; }

        protected override void OnRequestCreated(IRequest request)
        {
            this.RequestCreatedVisited = true;
        }

        protected override void OnResponseReceived(IResponse response)
        {
            this.ResponseReceivedVisited = true;
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.RequestCreatedVisited = false;
            this.ResponseReceivedVisited = false;
            this.ContentType = ContentType.Json;
            TestRequestFactory.Request.CleanUp();
            TestRequestFactory.Response.CleanUp();
        }
    }
}
