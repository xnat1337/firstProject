using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCoreDemo.Models.Responses
{
      public class GetExistingPurchaseOrderResp
        {
            public int id { get; set; }
            public int petId { get; set; }
            public int quantity { get; set; }
            public DateTime shipDate { get; set; }
            public string status { get; set; }
            public bool complete { get; set; }
        }    
}
