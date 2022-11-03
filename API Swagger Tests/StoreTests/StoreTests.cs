using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SeleniumCoreDemo.Models.Responses;
using SeleniumCoreDemo.RestSharp.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.RestSharp.Store
{
    internal class StoreTests
    {
        public RestClient client;

        string baseUrl = "https://petstore.swagger.io/v2";

        [SetUp]
        public void SetUp()
        {
            client = new RestClient(baseUrl);
        }

        [Test]

        public void VerifyGetPurchaseOrderByIdReturnCorrectResult()
        {
            RestRequest request = new RestRequest("/store/order/921832", Method.Get);
            var response = client.Execute(request);
            var objGetStoreResp = JsonConvert.DeserializeObject<GetExistingPurchaseOrderResp>(response.Content);

            Assert.IsNotNull(objGetStoreResp.id);
            Assert.AreEqual(objGetStoreResp.status, "placed");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]

        public void VerifyGetNotExistingPurchaseOrderByIdReturnCorrectResult()
        {
            RestRequest request = new RestRequest("/store/order/1", Method.Get);
            var response = client.Execute(request);
            var objGetStoreResp = JsonConvert.DeserializeObject<GetNotExistingInventoryAndPurchaseOrderResp>(response.Content);

            Assert.AreEqual(objGetStoreResp.message, "Order not found");
            Assert.AreEqual(objGetStoreResp.type, "error");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void VerifyGetStoreInventorySoldReturnCorrectResult()
        {
            RestRequest request = new RestRequest("/store/inventory", Method.Get);
            var response = client.Execute(request);
            var objGetInventoryResp = JsonConvert.DeserializeObject<GetExistingInventoryResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(objGetInventoryResp.sold);
        }

        [Test]
        public void VerifyGetStoreInventoryAdoptedReturnCorrectResult()
        {
            RestRequest request = new RestRequest("/store/inventory", Method.Get);
            var response = client.Execute(request);
            var objGetInventoryResp = JsonConvert.DeserializeObject<GetExistingInventoryResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(objGetInventoryResp.adopted);
        }

        [Test]
        public void VerifyUserCanPlaceOrderForAPet()
        {
            RestRequest request = new RestRequest("/store/order", Method.Post);

            var createStoreReq = new CreateStoreReq();
            createStoreReq.id = 967;
            createStoreReq.petId = 1;
            createStoreReq.quantity = 10;
            createStoreReq.shipDate = DateTime.Now;
            createStoreReq.status = "placed";
            createStoreReq.complete = true;

            string strCreateStoreReq = JsonConvert.SerializeObject(createStoreReq);
            request.AddStringBody(strCreateStoreReq, DataFormat.Json);
            
            var response = client.Execute(request);

            var objResp = JsonConvert.DeserializeObject<GetExistingPurchaseOrderResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(createStoreReq.id, objResp.id);
            Assert.AreEqual(createStoreReq.quantity, objResp.quantity);            
            Assert.AreEqual(createStoreReq.status, objResp.status);
            Assert.AreEqual(createStoreReq.complete, objResp.complete);
            //Assert.AreEqual(createStoreReq.shipDate, objResp.shipDate); //how to fix date
        }

        [Test]
        public void VerifyUserCanDeleteAPlacedPurchaseOrder()
        {
            RestRequest request = new RestRequest("/store/order/967", Method.Delete);

            var response = client.Execute(request);

            var objResp = JsonConvert.DeserializeObject<GetNotExistingInventoryAndPurchaseOrderResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objResp.message, "967");
            Assert.AreEqual(objResp.type, "unknown");
        }
    }
}
