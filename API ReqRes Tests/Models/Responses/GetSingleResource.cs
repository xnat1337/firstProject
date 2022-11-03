using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.API_ReqRes_Tests.Models.Responses
{
    public class GetSingleResource
    {
        public Data data { get; set; }
        public Support support { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public string pantone_value { get; set; }
    }

}
