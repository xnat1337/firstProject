using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SeleniumCoreDemo.Models.Responses;
using SeleniumCoreDemo.RestSharp.Models;
using SeleniumCoreDemo.RestSharp.Models.Requests;
using SeleniumCoreDemo.RestSharp.Models.Responses.PetResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.RestSharp.Pet
{
    internal class PetTests
    {
        public RestClient client;

        string baseUrl = "https://petstore.swagger.io/v2";

        [SetUp]
        public void SetUp()
        {
            client = new RestClient(baseUrl);                      
        }

        [Test]
        public void VerifyGetPetReturnsCorrectResult()
        {
            RestRequest request = new RestRequest("/pet/9223372036854022151", Method.Get);
            var response = client.Execute(request);
            var objGetPetResp = JsonConvert.DeserializeObject<GetExistingPetResp>(response.Content);

            Assert.AreEqual(objGetPetResp.status, "available");
            Assert.IsNotNull(objGetPetResp.id);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void VerifyGetPetNonExistingReturnsCorrectResult()
        {
            RestRequest request = new RestRequest("/pet/23123", Method.Get);
            var response = client.Execute(request);
            var objGetPetResp = JsonConvert.DeserializeObject<GetNotExistingPetResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual(objGetPetResp.message, "Pet not found");
        }

        [Test]
        public void VerifyGetPetByStatusAvailableReturnCorrectResult()
        {
            RestRequest request = new RestRequest("/pet/findByStatus?status=available", Method.Get);
            var response = client.Execute(request);
            var objGetPetResp = JsonConvert.DeserializeObject<List<GetPetByStatusResp>>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            foreach (var item in objGetPetResp)
            {
                Assert.IsNotNull(item.id);
                Assert.AreEqual(item.status, "available");
            }
        }

        [Test]
        public void VerifyGetPetByStatusSoldReturnCorrectResult()
        {
            RestRequest request = new RestRequest("/pet/findByStatus?status=sold", Method.Get);
            var response = client.Execute(request);
            var objGetNotExistingPetResp = JsonConvert.DeserializeObject<List<GetPetByStatusResp>>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            foreach (var item in objGetNotExistingPetResp)
            {
                Assert.IsNotNull(item.id);
                Assert.AreEqual(item.status, "sold");
                                
            }
        }

        [Test]
        public void VerifyUserCanCreateNewPet()
        {
            RestRequest request = new RestRequest("/pet", Method.Post);
            
            var createPetReq = new CreatePetReq();
            createPetReq.id = 967;
            var category = new Category();
            category.name = "niki";
            createPetReq.category = category;
            createPetReq.name = "mikey";
            createPetReq.category.id = 679;
            createPetReq.photoUrls = new string[] { "https://asd.com/photo.jpg" };
            var tag = new Tag();
            tag.id = 0;
            tag.name = "testTag1";
            createPetReq.tags = new Tag[] { tag };
            createPetReq.status = "available";

            string strCreatePetReq = JsonConvert.SerializeObject(createPetReq);
            request.AddStringBody(strCreatePetReq, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetPetByStatusResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(objResp.id);
            Assert.AreEqual(createPetReq.name, objResp.name);
            Assert.AreEqual(createPetReq.tags[0].id, objResp.tags[0].id);
            Assert.AreEqual(createPetReq.tags[0].name, objResp.tags[0].name);
            Assert.AreEqual(createPetReq.category.name, objResp.category.name);
        }

        [Test]
        public void VerifyUserCanUpdateExistingPet()
        {
            RestRequest request = new RestRequest("/pet", Method.Put);

            var createPetReq = new CreatePetReq();
            createPetReq.id = 967;
            var category = new Category();
            category.id = 679;
            category.name = "Maikitu";
            createPetReq.category = category;
            createPetReq.name = "Mimito";
            createPetReq.photoUrls = new string[] { "https://photourl.com/photototo.jpg" };
            var tag = new Tag();
            tag.id = 0;
            tag.name = "TwoYearOldDoggo";
            createPetReq.tags = new Tag[] { tag };
            createPetReq.status = "available";

            string strCreatePetReq = JsonConvert.SerializeObject(createPetReq);
            request.AddStringBody(strCreatePetReq, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetExistingPetResp>(response.Content);

            Assert.IsNotNull(objResp.id);
            Assert.AreEqual(createPetReq.id, objResp.id);
            Assert.AreEqual(createPetReq.tags[0].name, objResp.tags[0].name);           
        }

        [Test]
        public void VerifyUserCanUpdatePetWithData()
        {
            RestRequest request = new RestRequest("pet/967", Method.Post);
            request.AddParameter("name", "Nikito");
            request.AddParameter("status", "available");

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetExistingPetResp>(response.Content);
        }

        [Test]
        public void VerifyUserCanDeleteAPet()
        {
            RestRequest request = new RestRequest("/pet/967", Method.Delete);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetNotExistingPetResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objResp.type, "unknown");
            Assert.AreEqual(objResp.message, "967");
        }
    }
}
