using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSystem_Entities.HTTPRequests
{
    public class HTTPRequest_WarehouseToRetail
    {
        public HTTPRequest_RetailToWarehouse.WarehouseCommand WarehouseCmd { get; set; }
        public Location Location { get; set; }
        public List<Product> Products { get; set; }
    }
}
