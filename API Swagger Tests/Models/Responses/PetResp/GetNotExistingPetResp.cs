using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Models.Responses
{
    public class GetNotExistingPetResp
    {
        public int code { get; set; }
        public string type { get; set; }
        public string message { get; set; }
    }

}
