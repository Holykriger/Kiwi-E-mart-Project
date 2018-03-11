using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSystem_Entities.HTTPRequests
{
    public class HTTPRequest_RetailerToClientGateway
    {
        public Cookie Cookie { get; set; }
        public Baskets Basket { get; set; }
        public List<Product> Products { get; set; }
        public HTTPRequest_ClientToGateway.RetailCommand RetailCmd { get; set; }
    }
}
