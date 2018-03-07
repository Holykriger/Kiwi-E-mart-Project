using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse = Warehouse.Warehouse;
using Product = ShoppingSystem_Entities.Product;
using Location = ShoppingSystem_Entities.Location;
namespace NewTheWareHouseController
{
    //Locations are bad WTF Shall WareHouse Have Location in sted of base values ???
    class Program
    {
        static void Main(string[] args)
        {
            //This is for testing
            Console.WriteLine("This is a Test Run");
            WareHouseController WHC = new WareHouseController();
            WHC.Start();
   
            Console.ReadLine();
        }
    }
    public class WareHouseController
    {
        public List<WareHouse> WareHouses = new List<WareHouse>(); // listen Af Ware Houses
        public List<Product> ProductList = new List<Product>(); // List Af Product som Kunen vil købe
        public void Start()
        {
            Console.WriteLine("Stating");
            TestRun();
            Console.WriteLine(WareHouses.Count);
            while (true)
            {
                Console.WriteLine("" +
                    "1 = AddWareHouse\n" +
                    "2 = Clear Console\n" +
                    "3 = FindClosestWareHouse\n" +
                    "4 = AddProduct to warehouse\n" +
                    "5 = Get List Of Products\n" +
                    "");
                string Text = Console.ReadLine();
                switch (Text)
                {
                    case "1": //AddWareHouse
                        Console.WriteLine("You Hae Chossen Add WareHouse");
                        Console.WriteLine("What County");
                        string County = Console.ReadLine();
                        Console.WriteLine("What Municipality");
                        string Municipality = Console.ReadLine();
                        int ID = WareHouses.Count+1;
                        AddWareHouse(ID, County, Municipality);
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
                       // FindClosestWareHouse();
                        break;
# region .           4 = AddProduct to warehouse
                    case "4":
                        Console.WriteLine("What Is its Name");
                        string Name = Console.ReadLine();
                        Console.WriteLine("How Many");
                        int Quantity = -1;
                        bool ValueCheck = false;
                        while (ValueCheck == false)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out Quantity))
                                ValueCheck = true;
                            else
                                Console.WriteLine("String could not be parsed. Plz use numbers");
                        }
                        
                        Console.WriteLine("At What Price");
                        ValueCheck = false;
                        int Price = -1;
                        while (ValueCheck == false)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out Price))
                                ValueCheck = true;
                            else
                                Console.WriteLine("String could not be parsed. Plz use numbers");
                        }

                        Console.WriteLine("Adding new Produck To List");
                        AddProductToWareHouse(ProductList.Count + 1, "Tomato", Price, Quantity);
                    break;
                    #endregion
#region .           5 = Get List Of Products
                    case "5":
                        foreach (var Product in ProductList)
                        {
                            Console.WriteLine("ID = " + Product.ID + " Name = " + Product.Name + " Quantity = " + Product.Quantity+ " Price = " + Product.Price);
                        }
                        break;
                    #endregion
                    default:
                        break;
                }
                Console.WriteLine(Text);
            }
        }
        public void TestRun()
        {
            AddWareHouse(1, "Danmark", "Esbjerg");
            AddWareHouse(2, "Tyskland", "München");
            AddWareHouse(3, "Norge", "Oslo");
            AddProductToWareHouse(1,"Tomato",150,20);
            AddProductToWareHouse(2, "TV", 2, 150);
            AddProductToWareHouse(3, "Radio", 10, 9);
        }
        private WareHouse AddWareHouse(int ID, string County, string Municipality)
        {
            int Id = ID;
            string county = County;
            string municipality = Municipality;
            WareHouse NewWareHouse = new WareHouse(Id, county, municipality);
            Task.Factory.StartNew(() => NewWareHouse);
            WareHouses.Add(NewWareHouse);
            return NewWareHouse;
        }
        private Product AddProductToWareHouse(int ID, string Name, int Price, int Quantity)
        {
            Product NewProduct = new Product();
            NewProduct.ID = ID;
            NewProduct.Name = Name;
            NewProduct.Price = 5;
            NewProduct.Quantity = 0;
            //NewProduct.Location = location;
            ProductList.Add(NewProduct);
            return NewProduct;
        }
        private List<WareHouse> FindClosestWareHouses(List<WareHouse> noneCheckedWareHouses, Location location)
        {
            //Contry First Then municipality
            List<WareHouse> CountryChecked = noneCheckedWareHouses.FindAll(x => x.country == location.Country);
            if (CountryChecked.Count == 0)
            {
                // if there are no warehouses in the Country is there no reason to send back a emty list and no reason to check Municipality
                return noneCheckedWareHouses;
            }
            List<WareHouse> MunicipalityChecked = noneCheckedWareHouses.FindAll(x => x.municipality == location.Municipality);
            if (MunicipalityChecked.Count == 0)
            {
                MunicipalityChecked.AddRange(noneCheckedWareHouses);
            }
            return MunicipalityChecked;
        }
        public List<Product> FindProduct(Product product, Location location)
        {
            List<Product> CurrentFound = new List<Product>();
            int QuantityLeft = product.Quantity;
            List<WareHouse> noneCheckedWareHouses = new List<WareHouse>();
            while (QuantityLeft != 0)
            {
                List<WareHouse> ClosestWarehousest = FindClosestWareHouses(noneCheckedWareHouses, location);
                foreach (var ClosestWarehouse in ClosestWarehousest)
                {
                    if (QuantityLeft != 0)
                    {
                        noneCheckedWareHouses.Remove(ClosestWarehouse);
                        int ClosestQuantity = ClosestWarehouse.ProductList.Find(x => x.ID == product.ID).Quantity;
                        if (QuantityLeft <= ClosestQuantity)
                        {
                            //example if we need 1 and the ware house have 20 QuantityLeft = 1 ClosestQuantity = 20, will want to remove 1 from ClosestQuantity and remove QuantityLeft value from QuantityLeft and that will allways = 0 so you just as well set it to 0
                            //adding it to the system
                            CurrentFound.Add(ClosestWarehouse.ProductList.Find(x => x.ID == product.ID));
                            //removing the Quantity
                            ClosestWarehouse.ProductList.Find(x => x.ID == product.ID).Quantity = -QuantityLeft;
                            QuantityLeft = 0;
                        }else
                        {
                            //adding it to the system
                            CurrentFound.Add(ClosestWarehouse.ProductList.Find(x => x.ID == product.ID));
                            //removing the Quantity
                            int Quantity = ClosestWarehouse.ProductList.Find(x => x.ID == product.ID).Quantity;
                            ClosestWarehouse.ProductList.Find(x => x.ID == product.ID).Quantity = 0;
                            QuantityLeft = -Quantity;
                            
                        };
                        
                    }
                }
            }
            List<Product> ReturnList = new List<Product>()
            {
                  new Product(){ID = -1,Name = "Apple",Quantity = 25,Location = new Location(){Area = 1,Country="Russia",Municipality="esbjerg"}}
                , new Product(){ID = -2,Name = "Apple",Quantity = 6 ,Location = new Location(){Area = 2,Country="Denmark",Municipality="esbjerg"}}
                , new Product(){ID = -3,Name = "Apple",Quantity = 25,Location = new Location(){Area = 3,Country="Russia",Municipality="esbjerg"}},
            };
            return ReturnList;
            return CurrentFound;
        }
        //public bool RemoveProducts(Product product)
        //{
        //
        //    WareHouse ClosestWarehouse = FindClosestWareHouses(WareHouses);
        //
        //    return true;
        //}
    }
}
