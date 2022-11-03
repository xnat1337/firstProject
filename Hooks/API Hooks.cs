//using BoDi;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TechTalk.SpecFlow;

//namespace SeleniumCoreDemo.Hooks
//{
//    [Binding]
//    internal class API_Hooks
//    {
//        string baseUrl = "https://petstore.swagger.io/v2";
//        public RestClient client;
//        private readonly IObjectContainer objectContainer;

//        public API_Hooks(IObjectContainer objectContainer)
//        {
//            this.objectContainer = objectContainer;
//        }

//        [BeforeScenario]
//        public void RestClientSetup()
//        {
//            client = new RestClient(baseUrl);
//            objectContainer.RegisterInstanceAs(client);
//        }
//    }
//}
