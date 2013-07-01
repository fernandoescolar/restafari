using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class RestafariTests: RestClientBase
    {
        public RestafariTests() : base(TestRequestFactory.Instance)
        {
        }

        [TestMethod]
        public void JsonHeadersTest()
        {
            const string jsonContentType = "application/json; charset=UTF-8";
            const string jsonAccept = "application/json";

            this.Post("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.ContentType, jsonContentType);
            Assert.AreEqual(TestRequestFactory.Request.Accept, jsonAccept);
        }

        [TestMethod]
        public void PostTest()
        {
            this.Post("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public void GetTest()
        {
            this.Get("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public void PutTest()
        {
            this.Put("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public void DeleteTest()
        {
            this.Delete("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public void PostStreamTest()
        {
            var actual = this.PostStream("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
            Assert.AreSame(TestRequestFactory.Response.Stream, actual);
        }

        [TestMethod]
        public void GetStreamTest()
        {
            var actual = this.GetStream("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
            Assert.AreSame(TestRequestFactory.Response.Stream, actual);
        }

        [TestMethod]
        public void PutStreamTest()
        {
            var actual = this.PutStream("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
            Assert.AreSame(TestRequestFactory.Response.Stream, actual);
        }

        [TestMethod]
        public void DeleteStreamTest()
        {
            var actual = this.DeleteStream("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
            Assert.AreSame(TestRequestFactory.Response.Stream, actual);
        }

        [TestMethod]
        public void BeginPostTest()
        {
            this.BeginPost("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public void BeginGetTest()
        {
            this.BeginGet("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public void BeginPutTest()
        {
            this.BeginPut("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public void BeginDeleteTest()
        {
            this.BeginDelete("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public async void AsyncPostTest()
        {
            await this.PostAsync("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public async void AsyncGetTest()
        {
            await this.GetAsync("fakeurl");
            
            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public async void AsyncPutTest()
        {
            await this.PutAsync("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }

        [TestMethod]
        public async void AsyncDeleteTest()
        {
            await this.DeleteAsync("fakeurl");

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, "fakeurl");
        }
    }
}
