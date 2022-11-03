using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SeleniumCoreDemo.Models.Responses;
using SeleniumCoreDemo.RestSharp.Models.Requests;
using SeleniumCoreDemo.RestSharp.Models.Responses.UserResp;
using System.Collections.Generic;
using System.Net;

namespace SeleniumCoreDemo.RestSharp.User
{
    internal class UserTests
    {
        public RestClient client;

        string baseUrl = "https://petstore.swagger.io/v2";

        [SetUp]
        public void SetUp()
        {
            client = new RestClient(baseUrl);
        }

        [Test]
        public void VerifyGetUserReturnCorrectResult()
        {
            RestRequest request = new RestRequest("/user/vethorm", Method.Get);
            var response = client.Execute(request);
            var objGetUserResp = JsonConvert.DeserializeObject<GetExistingUserResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void VerifyGetNotExistingUserReturnCorrectResult()
        {
            RestRequest request = new RestRequest("/user/vethorm", Method.Get);
            var response = client.Execute(request);
            var objGetUserResp = JsonConvert.DeserializeObject<GetNotExistingUserResp>(response.Content);

            Assert.AreEqual(objGetUserResp.message, "User not found");
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]

        public void VerifyLoginUserWorkCorrect()
        {
            RestRequest request = new RestRequest("/user/login?username=vethorm&password=321", Method.Get);
            var response = client.Execute(request);
            var objGetLoginUserResp = JsonConvert.DeserializeObject<GetUserLoginToSystemResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objGetLoginUserResp.type, "unknown");
        }

        [Test]
        public void VerifyLoginUserWithoutUsernameReturnCorrectAnswer()
        {
            RestRequest request = new RestRequest("/user/login?password=321", Method.Get);
            var response = client.Execute(request);
            var objGetLoginUserWithoutUsernameResp = JsonConvert.DeserializeObject<GetLoginUserResp>(response.Content);

            Assert.IsTrue(objGetLoginUserWithoutUsernameResp.message.Contains("logged in user session:"));
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Test]
        public void VerifyLoginUserWithoutPasswordReturnCorrectAnswer()
        {
            RestRequest request = new RestRequest("/user/login?username=vethorm", Method.Get);
            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetLoginUserResp>(response.Content);

            Assert.IsTrue(objResp.message.Contains("cannot login without password:"));
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Test]
        public void VerifyLoginUserWithoutNameAndPasswordReturnCorrectAnswer()
        {
            RestRequest request = new RestRequest("/user/login", Method.Get);
            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetLoginUserResp>(response.Content);

            Assert.IsTrue(objResp.message.Contains("username or password is missing:"));
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }

        [Test]
        public void VerifyLogoutUserWorkCorrect()
        {
            RestRequest request = new RestRequest("/user/login?username=vethorm&password=321", Method.Get);
            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetUserLogoutFromSystemResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void VerifyUserCanCreateNewUser()
        {
            RestRequest request = new RestRequest("/user", Method.Post);

            var createUserObj = new CreateOrUpdateUserReq();
            createUserObj.id = 967;
            createUserObj.USERNAME = "vethorm";
            createUserObj.firstName = "nikolay";
            createUserObj.lastName = "angelov";
            createUserObj.email = "legitEmail@gmail.com";
            createUserObj.password = "123";
            createUserObj.phone = "089";
            createUserObj.userStatus = 3;

            var strCreateUserObj = JsonConvert.SerializeObject(createUserObj);
            request.AddStringBody(strCreateUserObj, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<CreateOrUpdateUserResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objResp.message, createUserObj.id);
            Assert.AreEqual(objResp.type, "unknown");
        }

        [Test]

        public void VerifyUserCanUpdateAExistingUser()
        {
            RestRequest request = new RestRequest("/user/vethorm", Method.Put);

            var updateUserObj = new CreateOrUpdateUserReq();
            updateUserObj.id = 967;
            updateUserObj.USERNAME = "shishi";
            updateUserObj.firstName = "mirela";
            updateUserObj.lastName = "angelova";
            updateUserObj.email = "legitEmail@gmail.com";
            updateUserObj.password = "123";
            updateUserObj.phone = "089";
            updateUserObj.userStatus = 3;

            var strUpdateUserObj = JsonConvert.SerializeObject(updateUserObj);
            request.AddStringBody(strUpdateUserObj, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<CreateOrUpdateUserResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objResp.type, "unknown");
            Assert.AreEqual(objResp.message, "967");            
        }

        [Test]
        public void VerifyUserCanDeleteExistingUser()
        {
            RestRequest request = new RestRequest("/user/vethorm", Method.Delete);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<GetNotExistingUserResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objResp.type, "unknown");
            Assert.AreEqual(objResp.message, "vethorm");
        }

        [Test]
        public void VerifyUserCanCreateNewUserWithArray()
        {
            RestRequest request = new RestRequest("user/createWithArray", Method.Post);

            var createUserObj = new CreateOrUpdateUserReq();
            createUserObj.id = 967;
            createUserObj.USERNAME = "vethorm";
            createUserObj.firstName = "nikolay";
            createUserObj.lastName = "angelov";
            createUserObj.email = "legitEmail@gmail.com";
            createUserObj.password = "123";
            createUserObj.phone = "089";
            createUserObj.userStatus = 3;
            var objReq = new List<CreateOrUpdateUserReq> { createUserObj };

            var strCreateUserObj = JsonConvert.SerializeObject(objReq);
            request.AddStringBody(strCreateUserObj, DataFormat.Json);

            var response = client.Execute(request);
            var objResp = JsonConvert.DeserializeObject<CreateOrUpdateUserResp>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(objResp.message, "ok");
            Assert.AreEqual(objResp.type, "unknown");
        }
    }
}
