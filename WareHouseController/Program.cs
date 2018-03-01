using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse = Warehouse.Warehouse;
using Product = ShoppingSystem_Entities.Product;
using Location = ShoppingSystem_Entities.Location;
namespace WareHouseController
{
    class Program
    {
        List<WareHouse> WareHouse = new List<WareHouse>(); // listen Af Ware Houses
        List<Product> WareList = new List<Product>(); // List Af Product som Kunen vil købe
        static void Main(string[] args)
        {
            
            
        }
        public void TestRun()
        {
            AddWareHouse(1, "Danmark", "Esbjerg");
            AddWareHouse(2, "Tyskland", "München");
            AddWareHouse(3, "Norge", "Oslo");
        }
        private WareHouse AddWareHouse(int ID,string County,string Municipality)
        {
            int Id = ID;
            string county = County;
            string municipality = Municipality;
            WareHouse NewWareHouse = new WareHouse(Id, county, municipality);
            Task.Factory.StartNew(() => NewWareHouse);
            WareHouse.Add(NewWareHouse);
            return NewWareHouse;
        }
        private WareHouse FindClosestWareHouse(List<WareHouse> WareHouseList)
        {
            WareHouse ClosestWarehouse = new WareHouse(-1,"Error","Error");

            return ClosestWarehouse;
        }
        public List<WareHouse> FindProduct(Product product, Location location)
        {
            
            WareHouse ClosestWarehouse = FindClosestWareHouse(WareHouse);

            return new List<WareHouse>();
        }
        public bool RemoveProducts(Product product)
        {

            WareHouse ClosestWarehouse = FindClosestWareHouse(WareHouse);

            return true;
        }
    }
}
