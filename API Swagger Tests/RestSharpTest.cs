using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SeleniumCoreDemo.Models.Responses;
using System.Net;

namespace SeleniumCoreDemo.RestSharp
{
    internal class RestSharpTest
    {
        //[Test]
        //public void VerifyGetFirstPetReturnsCorrectResult()
        //{
        //    var client = new RestClient("https://petstore.swagger.io/v2");
        //    var request = new RestRequest("/pet/9223372036854022151", Method.Get);
        //    var response = client.Execute(request);
        //    Assert.AreEqual(HttpStatusCode.NotFound ,response.StatusCode);

        //    var objGetPetResp = JsonConvert.DeserializeObject<GetExistingPetResp>(response.Content);
        //    Assert.AreEqual(objGetPetResp.status, "available");
        //    Assert.IsNotNull(objGetPetResp.id);
        //}

        //[Test]

        //public void VerifyGetFirstPetNonExistingReturnsCorrectResult()
        //{
        //    var client = new RestClient("https://petstore.swagger.io/v2");
        //    var request = new RestRequest("/pet/9223372036854022151", Method.Get);
        //    var response = client.Execute(request);
        //    var objGetPetResp = JsonConvert.DeserializeObject<GetNotExistingPetResp>(response.Content);

        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        //    Assert.AreEqual(objGetPetResp.message, "Pet not found");
        //}

        //[Test]

        //public void VerifyGetPetByStatusReturnCorrectResult()
        //{            
        //    var client = new RestClient("https://petstore.swagger.io/v2");
        //    var request = new RestRequest("/pet/findByStatus?status=available", Method.Get);
        //    var response = client.Execute(request);
        //    var objGetPetResp = JsonConvert.DeserializeObject<List<GetExistingPetResp>>(response.Content);

        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    foreach (var item in objGetPetResp)
        //    {
        //        Assert.IsNotNull(item.id);
        //        Assert.AreEqual(item.status, "available");
        //    }
        //}

        //[Test]

        //public void VerifyGetNotExistingPetByStatusReturnCorrectResult()
        //{
        //    var client = new RestClient("https://petstore.swagger.io/v2");
        //    var request = new RestRequest("/pet/findByStatus?status=available", Method.Get);
        //    var response = client.Execute(request);
        //    var objGetNotExistingPetResp = JsonConvert.DeserializeObject<List<GetExistingPetResp>>(response.Content);

        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        //    foreach(var item in objGetNotExistingPetResp)
        //    {
        //        Assert.IsNotNull(item.id);
        //        Assert.AreEqual(item.status, "unavailable");
        //    }
        //}

        //[Test]

        //public void VerifyGetPurchaseOrderByIdReturnCorrectResult()
        //{
        //    var client = new RestClient("https://petstore.swagger.io/v2");
        //    var request = new RestRequest("/store/order/921832", Method.Get);
        //    var response = client.Execute(request);
        //    var objGetStoreResp = JsonConvert.DeserializeObject<GetExistingPurchaseOrderResp>(response.Content);

        //    Assert.IsNotNull(objGetStoreResp.id);
        //    Assert.AreEqual(objGetStoreResp.status, "placed");
        //    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //} 

        //[Test]

        //public void VerifyGetNotExistingPurchaseOrderByIdReturnCorrectResult()
        //{
        //    var client = new RestClient("https://petstore.swagger.io/v2");
        //    var request = new RestRequest("/store/order/1", Method.Get);
        //    var response = client.Execute(request);
        //    var objGetStoreResp = JsonConvert.DeserializeObject<GetNotExstingPurchaseOrderByIdReturnCorrectResult>(response.Content);

        //    Assert.AreEqual(objGetStoreResp.message, "Order not found");
        //    Assert.AreEqual(objGetStoreResp.type, "error");
        //    Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        //}

        //[Test]
        //public void VerifyGetPetInventoriesReturnCorrectResult()
        //{
        //    var client = new RestClient("https://petstore.swagger.io/v2");
        //    var request = new RestRequest("/store/inventory", Method.Get);
        //    var response = client.Execute(request);
        //    var objGetInventoryResp = JsonConvert.DeserializeObject<GetExistingInventoryResp>(response.Content);

        //    Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
        //    Assert.AreEqual(objGetInventoryResp.sold, 2);
        //}

        //    [Test]
        //    public void VerifyGetUserReturnCorrectResult()
        //    {
        //        var client = new RestClient("https://petstore.swagger.io/v2");
        //        var request = new RestRequest("/user/vethorm", Method.Get);
        //        var response = client.Execute(request);
        //        var objGetUserResp = JsonConvert.DeserializeObject<GetExistingUserResp>(response.Content);

        //        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        //    }

        //    [Test]
        //    public void VerifyGetNotExistingUserReturnCorrectResult()
        //    {
        //        var client = new RestClient("https://petstore.swagger.io/v2");
        //        var request = new RestRequest("/user/vethorm", Method.Get);
        //        var response = client.Execute(request);
        //        var objGetUserResp = JsonConvert.DeserializeObject<GetNotExistingUserResp>(response.Content);

        //        Assert.AreEqual(objGetUserResp.message, "User not found");
        //        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        //    }

        //    [Test]

        //    public void VerifyLoginUserWorkCorrect()
        //    {
        //        var client = new RestClient("https://petstore.swagger.io/v2");
        //        var request = new RestRequest("/user/login?username=vethorm&password=321", Method.Get);
        //        var response = client.Execute(request);
        //        var objGetLoginUserResp = JsonConvert.DeserializeObject<GetUserLoginToSystemResp>(response.Content);

        //        Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
        //        Assert.AreEqual(objGetLoginUserResp.type, "unknown");
        //    }

        //    [Test]
        //    public void VerifyLoginUserWithoutUsernameReturnCorrectAnswer()
        //    {
        //        var client = new RestClient("https://petstore.swagger.io/v2");
        //        var request = new RestRequest("/user/login?password=321", Method.Get);
        //        var response = client.Execute(request);
        //        var objGetLoginUserWithoutUsernameResp = JsonConvert.DeserializeObject<GetLoginUserResp>(response.Content);

        //        Assert.IsTrue(objGetLoginUserWithoutUsernameResp.message.Contains("logged in user session:"));
        //        Assert.AreEqual(HttpStatusCode.Forbidden,response.StatusCode);           
        //    }

        //    [Test]
        //    public void VerifyLoginUserWithoutPasswordReturnCorrectAnswer()
        //    {
        //        var client = new RestClient("https://petstore.swagger.io/v2");
        //        var request = new RestRequest("/user/login?username=vethorm", Method.Get);
        //        var response = client.Execute(request);
        //        var objResp = JsonConvert.DeserializeObject<GetLoginUserResp>(response.Content);

        //        Assert.IsTrue(objResp.message.Contains("cannot login without password:"));
        //        Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        //    }

        //    [Test]
        //    public void VerifyLoginUserWithoutNameAndPasswordReturnCorrectAnswer()
        //    {
        //        var client = new RestClient("https://petstore.swagger.io/v2");
        //        var request = new RestRequest("/user/login", Method.Get);
        //        var response = client.Execute(request);
        //        var objResp = JsonConvert.DeserializeObject<GetLoginUserResp>(response.Content);

        //        Assert.IsTrue(objResp.message.Contains("username or password is missing:"));
        //        Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        //    }

        //    [Test]
        //    public void VerifyLogoutUserWorkCorrect()
        //    {
        //        var client = new RestClient("https://petstore.swagger.io/v2");
        //        var request = new RestRequest("/user/login?username=vethorm&password=321", Method.Get);
        //        var response = client.Execute(request);
        //        var objResp = JsonConvert.DeserializeObject<GetUserLogoutFromSystemResp>(response.Content);

        //        Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
        //    }
        //}
    }
}
