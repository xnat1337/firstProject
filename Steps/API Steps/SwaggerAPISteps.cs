using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SeleniumCoreDemo.RestSharp.Models.Requests;
using SeleniumCoreDemo.RestSharp.Models.Responses.UserResp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumCoreDemo.Steps.API_Steps
{
    
    [Binding]    
    internal class SwaggerAPISteps
    {
        RestClient client;
        RestResponse response;
        public SwaggerAPISteps(RestClient client)
        {
            this.client = client; 
        }

        [When(@"a user do POST request to ""([^""]*)""")]
        public void GivenAUserDoPOSTRequestTo(string p0)
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
            response = client.Execute(request);
        }


        [Then(@"status code ""(.*)"" is returned")]
        public void WhenStatusCodeIsReturned(int statusCode)
        {
            Assert.AreEqual((HttpStatusCode)statusCode, response.StatusCode);
        }

        [Then(@"response contains correct user data")]
        public void ThenResponseContainsCorrectUserData()
        {
            var objResp = JsonConvert.DeserializeObject<CreateOrUpdateUserResp>(response.Content);
            Assert.AreEqual(objResp.message, "967");
            Assert.AreEqual(objResp.type, "unknown");
        }

    }
}
