using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSystem_Entities.HTTPRequests
{
    public class HTTPRequest_ClientToGateway
    {
        public Location Location;
        public User User { get; set; } //If 'User' != null, attempt to log in. If 'User' == null, use other command that is defined in request.
        public Cookie Cookie { get; set; }
        public Product Product { get; set; }
        public RetailCommand RetailCmd { get; set; }
        public enum RetailCommand { Login, AddProduct, RemoveProduct, ViewAllProducts }
    }
}
