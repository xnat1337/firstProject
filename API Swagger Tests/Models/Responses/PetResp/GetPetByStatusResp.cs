﻿using SeleniumCoreDemo.RestSharp.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.RestSharp.Models.Responses.PetResp
{

    public class GetPetByStatusResp
    {
        public long id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public Tag[] tags { get; set; }
        public string status { get; set; }
    }

}

