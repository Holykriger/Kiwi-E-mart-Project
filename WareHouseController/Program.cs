using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse = Warehouse.Warehouse;
using Product = ShoppingSystem_Entities.Product;
namespace WareHouseController
{
    class Program
    {
        List<WareHouse> WareHouse = new List<WareHouse>(); // listen Af Ware Houses
        List<Product> WareList = new List<Product>(); // List Af Product som Kunen vil købe
        static void Main(string[] args)
        {
            
        }
        private void AddWareHouse(int ID,string County,string Municipality)
        {
            int Id = ID;
            string county = County;
            string municipality = Municipality;
            WareHouse.Add(new WareHouse(Id,county,municipality));
        }
        private WareHouse FindClosestWareHouse()
        {
            WareHouse ClosestWarehouse = new WareHouse(-1,"Error","Error");

            return ClosestWarehouse;
        }
    }
}
