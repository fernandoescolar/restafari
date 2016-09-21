using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restafari.Tests.Mocks;

namespace Restafari.Tests
{
    [TestClass]
    public class RestafariTests: RestClientBase
    {
        private const string FakeUrl = "http://fakeUrl";

        public RestafariTests() : base(TestRequestFactory.Instance)
        {
        }

        [TestMethod]
        public void JsonHeadersTest()
        {
            const string jsonContentType = "application/json; charset=utf-8";
            const string jsonAccept = "application/json";

            this.Post(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.ContentType, jsonContentType);
            Assert.AreEqual(TestRequestFactory.Request.Accept, jsonAccept);
        }

        [TestMethod]
        public void PostTest()
        {
            this.Post(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void GetTest()
        {
            this.Get(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void PutTest()
        {
            this.Put(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void DeleteTest()
        {
            this.Delete(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void PostStreamTest()
        {
            var actual = this.PostStream(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
            Assert.AreSame(TestRequestFactory.Response.Stream, actual);
        }

        [TestMethod]
        public void GetStreamTest()
        {
            var actual = this.GetStream(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
            Assert.AreSame(TestRequestFactory.Response.Stream, actual);
        }

        [TestMethod]
        public void PutStreamTest()
        {
            var actual = this.PutStream(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
            Assert.AreSame(TestRequestFactory.Response.Stream, actual);
        }

        [TestMethod]
        public void DeleteStreamTest()
        {
            var actual = this.DeleteStream(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
            Assert.AreSame(TestRequestFactory.Response.Stream, actual);
        }

        [TestMethod]
        public void PostWithRequestSettingsTest()
        {
            this.Post(new RequestSettings { Url = FakeUrl });

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void GetWithRequestSettingsTest()
        {
            this.Get(new RequestSettings { Url = FakeUrl });

            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void PutWithRequestSettingsTest()
        {
            this.Put(new RequestSettings { Url = FakeUrl });

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void DeleteWithRequestSettingsTest()
        {
            this.Delete(new RequestSettings { Url = FakeUrl });

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void BeginPostTest()
        {
            this.BeginPost(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void BeginGetTest()
        {
            this.BeginGet(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void BeginPutTest()
        {
            this.BeginPut(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public void BeginDeleteTest()
        {
            this.BeginDelete(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        [ExpectedException(typeof(RestClientException))]
        public void OnErrorTest()
        {
            TestRequestFactory.Response.CreateException();
            var expected = this.Post<int>(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
            Assert.AreEqual(expected, int.MaxValue);
        }

        [TestMethod]
        public async Task AsyncPostTest()
        {
            await this.PostAsync(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncGetTest()
        {
            await this.GetAsync(FakeUrl);
            
            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncPutTest()
        {
            await this.PutAsync(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncDeleteTest()
        {
            await this.DeleteAsync(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncPostStreamTest()
        {
            await this.PostStreamAsync(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncGetStreamTest()
        {
            await this.GetStreamAsync(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncPutStreamTest()
        {
            await this.PutStreamAsync(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncDeleteStreamTest()
        {
            await this.DeleteStreamAsync(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncPostWithRequestSettingsTest()
        {
            await this.PostAsync(new RequestSettings { Url = FakeUrl });

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncGetWithRequestSettingsTest()
        {
            await this.GetAsync(new RequestSettings { Url = FakeUrl });

            Assert.AreEqual(TestRequestFactory.Request.Method, "GET");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncPutWithRequestSettingsTest()
        {
            await this.PutAsync(new RequestSettings { Url = FakeUrl });

            Assert.AreEqual(TestRequestFactory.Request.Method, "PUT");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        public async Task AsyncDeleteWithRequestSettingsTest()
        {
            await this.DeleteAsync(new RequestSettings { Url = FakeUrl });

            Assert.AreEqual(TestRequestFactory.Request.Method, "DELETE");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
        }

        [TestMethod]
        [ExpectedException(typeof(RestClientException))]
        public async Task AsyncOnErrorTest()
        {
            TestRequestFactory.Response.CreateException();
            var expected = await this.PostAsync<int>(FakeUrl);

            Assert.AreEqual(TestRequestFactory.Request.Method, "POST");
            Assert.AreEqual(TestRequestFactory.Request.Url, FakeUrl);
            Assert.AreEqual(expected, int.MaxValue);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            TestRequestFactory.Request.CleanUp();
            TestRequestFactory.Response.CleanUp();
        }
    }
}
