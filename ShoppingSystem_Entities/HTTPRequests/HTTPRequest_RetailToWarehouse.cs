using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSystem_Entities.HTTPRequests
{
    public class HTTPRequest_RetailToWarehouse
    {
        public enum WarehouseCommand { ViewProducts, PurchaseProducts }
        public WarehouseCommand WarehouseCmd { get; set; }
        public List<Product> Products { get; set; }
    }
}
