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
                    "4 = AddProduct\n" +
                    "5 = Get List Of Products\n" +
                    "6 = AddProduct to warehouse\n" +
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
                        Console.WriteLine("use Call Nun To Select With product you want");
                        TestFunktionShowProducktList();
                        int productNun = -1;
                        bool productNunCheck = false;
                        while (productNunCheck == false)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out productNun))
                                productNunCheck = true;
                            else
                                Console.WriteLine("String could not be parsed. Plz use numbers");
                        }
                        Console.WriteLine("How Many");
                        int amount = -1;
                        bool amountCheck = false;
                        while (amountCheck == false)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out amount))
                                amountCheck = true;
                            else
                                Console.WriteLine("String could not be parsed. Plz use numbers");
                        }
                        Product productLookingFor = new Product();
                        productLookingFor.ID = ProductList[productNun].ID;
                        productLookingFor.Name = ProductList[productNun].Name;
                        productLookingFor.Quantity = amount;
                        Console.WriteLine("\nWere From");
                        Location location = new Location() { };
                        Console.WriteLine("what Country");
                        location.Country = Console.ReadLine();
                        Console.WriteLine("what Municipality");
                        location.Municipality = Console.ReadLine();
                        productLookingFor.Location = location;
                        List<Product> PL = FindProduct(productLookingFor);
                        foreach (var p in PL)
                        {
                            Console.WriteLine(p.Location.Country + " Name = " + p.Name + " Price = " + p.Price + " Quantity = " + p.Quantity);
                        }
                        break;
# region .           4 = AddProduct
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
                        AddProduct(ProductList.Count + 1, "Tomato", Price, Quantity);
                    break;
                    #endregion
#region .           5 = Get List Of Products
                    case "5":
                        TestFunktionShowProducktList();
                        break;
                    #endregion
#region .           6 = AddProduct to warehouse
                    case "6":
                        Console.WriteLine("use Call Nun To Select With product you want to use");
                        TestFunktionShowProducktList();
                        int productID = -1;
                        bool productIDCheck = false;
                        while (productIDCheck == false)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out productID))
                                productIDCheck = true;
                            else
                                Console.WriteLine("String could not be parsed. Plz use numbers");
                        }
                        
                        Console.WriteLine("use Call Nun To Select With WareHouse you want to use");
                        TestFunktionShowWareHouseList();
                        int warHouseID = -1;
                        bool warHouseIDCheck = false;
                        while (warHouseIDCheck == false)
                        {
                            if (Int32.TryParse(Console.ReadLine(), out warHouseID))
                                warHouseIDCheck = true;
                            else
                                Console.WriteLine("String could not be parsed. Plz use numbers");
                        }
                        if (ProductList[productID] != null && WareHouses[warHouseID] != null)
                        {
                            AddProductToWareHouse(ProductList[productID], WareHouses[warHouseID]);
                        }
                        break;
#endregion
                    default:
                        break;
                }
                Console.WriteLine(Text);
            }
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
        private Product AddProduct(int ID, string Name, int Price, int Quantity)
        {
            Product NewProduct = new Product();
            NewProduct.ID = ID;
            NewProduct.Name = Name;
            NewProduct.Price = 5;
            NewProduct.Quantity = Quantity;
            //NewProduct.Location = location;
            ProductList.Add(NewProduct);
            return NewProduct;
        }
        private void AddProductToWareHouse(Product product, WareHouse warehouse)
        {
            warehouse.ProductList.Add(product);
            Location location = new Location();
            location.Country = warehouse.country;
            location.Municipality = warehouse.municipality;
            product.Location = location;
        }
        private List<WareHouse> FindClosestWareHouses(List<WareHouse> noneCheckedWareHouses, Location location)
        {
            //Contry First Then municipality
            List<WareHouse> CountryChecked = noneCheckedWareHouses.FindAll(x => x.country == location.Country);
            if (CountryChecked.Count == 0)
            {
                // if there are no warehouses in the Country is there no reason to send back a emty list and no reason to check Municipality
                List<WareHouse> LW = new List<WareHouse>();
                LW.AddRange(noneCheckedWareHouses);
                return LW;
            }
            List<WareHouse> MunicipalityChecked = CountryChecked.FindAll(x => x.municipality == location.Municipality);
            if (MunicipalityChecked.Count == 0)
            {
                MunicipalityChecked.AddRange(CountryChecked);
            }
            return MunicipalityChecked;
        }

        // the incoming prouct is use as a description of what the customor wants,
        public List<Product> FindProduct(Product product)
        {
            List<Product> CurrentFound = new List<Product>();
            int QuantityLeft = product.Quantity;
            List<WareHouse> noneCheckedWareHouses = new List<WareHouse>();
            noneCheckedWareHouses.AddRange(WareHouses);
            while (QuantityLeft != 0 && noneCheckedWareHouses.Count != 0)
            {
                List<WareHouse> ClosestWarehousest = FindClosestWareHouses(noneCheckedWareHouses, product.Location);
                if (ClosestWarehousest.Count != 0)
                {
                    //Current Bug is on quantaty
                foreach (var ClosestWarehouse in ClosestWarehousest)
                {
                    if (QuantityLeft != 0)          //NOTE Maybe use Name insted of ID
                    {
                        noneCheckedWareHouses.Remove(ClosestWarehouse);
                        int ClosestQuantity = ClosestWarehouse.ProductList.Find(x => x.Name == product.Name).Quantity;
                        if (QuantityLeft <= ClosestQuantity)
                        {
                                //example if we need 1 and the ware house have 20 QuantityLeft = 1 ClosestQuantity = 20, will want to remove 1 from ClosestQuantity and remove QuantityLeft value from QuantityLeft and that will allways = 0 so you just as well set it to 0
                                //adding it to the system
                                Product foundproduct = new Product();
                                Product foundproductInWareHouse = ClosestWarehouse.ProductList.Find(x => x.Name == product.Name);
                                foundproduct.ID = foundproductInWareHouse.ID;
                                foundproduct.Name = foundproductInWareHouse.Name;
                                foundproduct.Price = foundproductInWareHouse.Price;
                                foundproduct.Location = foundproductInWareHouse.Location;
                                foundproduct.Quantity = QuantityLeft;
                                CurrentFound.Add(foundproduct);
                            //removing the Quantity
                            ClosestWarehouse.ProductList.Find(x => x.Name == product.Name).Quantity -= QuantityLeft;
                            QuantityLeft = 0;
                        }else
                        {
                                //adding it to the system
                                Product foundproduct = new Product();
                                Product foundproductInWareHouse = ClosestWarehouse.ProductList.Find(x => x.Name == product.Name);
                                foundproduct.ID = foundproductInWareHouse.ID;
                                foundproduct.Name = foundproductInWareHouse.Name;
                                foundproduct.Price = foundproductInWareHouse.Price;
                                foundproduct.Location = foundproductInWareHouse.Location;
                                foundproduct.Quantity = ClosestQuantity;
                                CurrentFound.Add(foundproduct);
                            //removing the Quantity
                            
                            ClosestWarehouse.ProductList.Find(x => x.Name == product.Name).Quantity = 0;
                            QuantityLeft -= ClosestQuantity;
                            
                        };
                        
                    }
                }
                }
            }
           // return ReturnList;
            return CurrentFound;
        }
        //public bool RemoveProducts(Product product)
        //{
        //
        //    WareHouse ClosestWarehouse = FindClosestWareHouses(WareHouses);
        //
        //    return true;
        //}
// From Here on Down Is Funktions Design For Testing
        private void TestFunktionShowProducktList()
        {
            int num = 0;
            foreach (var Product in ProductList)
            {
                string CountryText = "None";
                string MunicipalityText = "None";
                if (Product.Location != null)
                {
                    if (Product.Location.Country != null)
                    {
                        CountryText = Product.Location.Country;
                    }
                    if (Product.Location.Municipality != null)
                    {
                        MunicipalityText = Product.Location.Municipality;
                    }
                }
                Console.WriteLine("Call Nun " + num + " ID = " + Product.ID + " Name = " + Product.Name + " Quantity = " + Product.Quantity + " Price = " + Product.Price +
                " Country = " + CountryText + " Municipality = " + MunicipalityText);
                num++;
            }
        }
        private void TestFunktionShowWareHouseList()
        {
            int num = 0;
            foreach (var warHouse in WareHouses)
            {
                string CountryText = "None";
                string MunicipalityText = "None";
                if (warHouse.country != null)
                {
                    CountryText = warHouse.country;
                }
                if (warHouse.municipality != null)
                {
                    MunicipalityText = warHouse.municipality;
                }
                Console.WriteLine("Call Nun " + num + " ID = " + warHouse.id + " country = " + CountryText + " municipality = " + MunicipalityText);
                num++;
            }
        }
        private void TestRun()
        {
            AddWareHouse(1, "Danmark", "Esbjerg");
            AddWareHouse(2, "Tyskland", "München");
            AddWareHouse(3, "Norge", "Oslo");
            ;
            AddProduct(2, "TV", 2, 150);
            AddProduct(3, "Radio", 10, 9);
            AddProductToWareHouse(AddProduct(1, "Tomato", 3, 20), WareHouses[0]);
            AddProductToWareHouse(AddProduct(1, "Tomato", 3, 25), WareHouses[1]);
            AddProductToWareHouse(AddProduct(1, "Tomato", 3, 26), WareHouses[2]);
        }
    }
}
