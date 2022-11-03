using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.RestSharp.Models.Responses.UserResp
{
    public class CreateOrUpdateUserResp
    {
        public int code { get; set; }
        public string type { get; set; }
        public string message { get; set; }
    }

}
