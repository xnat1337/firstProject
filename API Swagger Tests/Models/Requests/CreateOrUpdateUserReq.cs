using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.RestSharp.Models.Requests
{
    public class CreateOrUpdateUserReq
    {
        public int id { get; set; }
        public string USERNAME { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public int userStatus { get; set; }
    }
}


