using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.API_ReqRes_Tests.Models.Responses
{
    public class GetListUsersResp
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public DataUserResp[] data { get; set; }
        public Support support { get; set; }
    }
}
