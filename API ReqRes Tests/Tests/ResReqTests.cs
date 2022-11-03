using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SeleniumCoreDemo.API_ReqRes_Tests.Models.Requests;
using SeleniumCoreDemo.API_ReqRes_Tests.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.API_ReqRes_Tests.Tests
{
    internal class ResReqTests
    {
        public RestClient client;
        string baseUrl = "https://reqres.in/";

        [SetUp]

        public void Setup()
        {
            client = new RestClient(baseUrl);
        }

        [Test]
        public void VerifyGetUsersListWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/users?page=2", Method.Get);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetListUsersResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objResp.page, 2);
            Assert.AreEqual(objResp.support.url, "https://reqres.in/#support-heading");
            Assert.IsNotNull(objResp.support.text);
            foreach (var item in objResp.data)
            {
                Assert.IsNotNull(item.id);
                Assert.IsNotNull(item.email);
                Assert.IsNotNull(item.first_name);
                Assert.IsNotNull(item.last_name);
                Assert.IsNotNull(item.avatar);
            }
        }

        [Test]
        public void VerifyGetUserWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/users/2", Method.Get);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetUserResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(objResp.data.email);
            Assert.IsNotNull(objResp.data.first_name);
            Assert.IsNotNull(objResp.data.last_name);
            Assert.IsNotNull(objResp.data.avatar);
            Assert.IsNotNull(objResp.support.url);
            Assert.IsNotNull(objResp.support.text);
            Assert.AreEqual(objResp.data.id, 2);
        }

        [Test]
        public void VerifyGetUserNotFound ()
        {
            RestRequest request = new RestRequest("/api/users/23", Method.Get);

            var response = client.Execute(request);
            
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);            
        }

        [Test]
        public void VerifyGetListResourceWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/unknown", Method.Get);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetListResource>(response.Content);

            Assert.AreEqual (HttpStatusCode.OK, response.StatusCode);
            foreach(var item in objResp.data)
            {
                Assert.IsNotNull(item.id);
                Assert.IsNotNull(item.name);
                Assert.IsNotNull(item.year);
                Assert.IsNotNull(item.color);
                Assert.IsNotNull(item.pantone_value);
            }                   
        }

        [Test]
        public void VerifyGetSingleResourceWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/unknown/2", Method.Get);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetSingleResource>(response.Content);
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(objResp.data.id);
            Assert.IsNotNull(objResp.data.name);
            Assert.IsNotNull(objResp.data.year);
            Assert.IsNotNull(objResp.data.color);
            Assert.IsNotNull(objResp.data.pantone_value);
            Assert.AreEqual(objResp.support.url, "https://reqres.in/#support-heading");
            Assert.IsNotNull(objResp.support.text);
        }

        [Test]
        public void VerifySingleResourceNotFoundWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/unknown/23", Method.Get);

            var response = client.Execute(request);
            
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void VerifyCreateUserWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/users", Method.Post);

            var objReq = new CreateOrUpdateUserReq();
            objReq.name = "morpheus";
            objReq.job = "leader";

            string strObjReq = JsonConvert.SerializeObject(objReq);
            request.AddStringBody(strObjReq, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetCreateUserResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual(objReq.name, objResp.name);
            Assert.AreEqual(objResp.job, objResp.job); 
        }

        [Test]
        public void VerifyUpdateUserWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/users/2", Method.Put);

            var objReq = new CreateOrUpdateUserReq();
            objReq.name = "morpheus";
            objReq.job = "zion resident";

            string strObjReq = JsonConvert.SerializeObject(objReq);
            request.AddStringBody(strObjReq, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetUpdatedUserResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objReq.name, objResp.name);
            Assert.AreEqual(objReq.job, objResp.job);
            Assert.IsNotNull(objResp.updatedAt);
        }

        [Test]
        public void VerifyPatchUserWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/users/2", Method.Patch);

            var objReq = new CreateOrUpdateUserReq();
            objReq.name = "morpheus";
            objReq.job = "zion resident";

            string strObjReq = JsonConvert.SerializeObject(objReq);
            request.AddStringBody(strObjReq, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetUpdatedUserResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objReq.name, objResp.name);
            Assert.AreEqual(objReq.job, objResp.job);
            Assert.IsNotNull(objResp.updatedAt);
        }

        [Test]
        public void VerifyDeleteUserWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/users/2", Method.Delete);

            var response = client.Execute(request);
            
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test]
        public void VerifyRegisterNewUserWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/register", Method.Post);

            var objReq = new RegisterOrLoginReq();
            objReq.email = "eve.holt@reqres.in";
            objReq.password = "pistol";

            string strObjReq = JsonConvert.SerializeObject(objReq);
            request.AddStringBody(strObjReq, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<RegisterSucResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(objReq.email);
            Assert.IsNotNull(objReq.password);
            Assert.IsNotNull(objResp.id);
            Assert.IsNotNull(objResp.token);
        }

        [Test]
        public void VerifyRegisterUnsuccessfulReturnCorrectResponse()
        {
            RestRequest request = new RestRequest("/api/register",Method.Post);

            var objReq = new RegisterOrLoginWithEmailOnlyReq();
            objReq.email = "sydney@fife";

            string strObjReq = JsonConvert.SerializeObject(objReq);
            request.AddStringBody(strObjReq, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<UnsuccessfulRegisterOrLoginResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(objReq.email);
            Assert.IsNotNull(objResp.error);
        }

        [Test]
        public void VerifyUserLoginSuccessfulWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/login", Method.Post);

            var objReq = new RegisterOrLoginReq();
            objReq.email = "eve.holt@reqres.in";
            objReq.password = "cityslicka";

            string strObjReq = JsonConvert.SerializeObject(objReq);
            request.AddStringBody(strObjReq, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<LoginSuccessfulResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(objReq.email);
            Assert.IsNotNull(objReq.password);
            Assert.IsNotNull(objResp.token);
        }

        [Test]
        public void VerifyUserLoginUnsuccessfulWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/login",Method.Post);

            var objReq = new RegisterOrLoginWithEmailOnlyReq();
            objReq.email = "peter@klaven";

            string strObjReq = JsonConvert.SerializeObject(objReq);
            request.AddStringBody(strObjReq, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<UnsuccessfulRegisterOrLoginResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.IsNotNull(objReq.email);
            Assert.IsNotNull(objResp.error);
        }

        [Test]
        public void VerifyGetDelayedResponseWorkCorrect()
        {
            RestRequest request = new RestRequest("/api/users?delay=3", Method.Get);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetListUsersResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
            foreach(var item in objResp.data)
            {
                Assert.IsNotNull(item.id);
                Assert.IsNotNull(item.email);
                Assert.IsNotNull(item.first_name);
                Assert.IsNotNull(item.last_name);
                Assert.IsNotNull(item.avatar);
            }
        }
    }
}
