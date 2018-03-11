using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;

namespace Checkout
{
    class Program
    {
        static void Main(string[] args)
        {
            //Manages checkout including payment, shipping cost and delivery time.
            Console.WriteLine("Hello World!");
            new TestClass();
        }
    }
    public class TestClass
    {
        
        private Product AddProduct(int ID, string Name, int Price, int Quantity)
        {
            Product NewProduct = new Product();
            NewProduct.ID = ID;
            NewProduct.Name = Name;
            NewProduct.Price = 5;
            NewProduct.Quantity = Quantity;
            NewProduct.Location = new Location();
            return NewProduct;
        }
        private Location AddLocation(string County, string Municipality)
        {
            Location NewLocation = new Location();
            NewLocation.Country = County;
            NewLocation.Municipality = Municipality;
            return NewLocation;
        }
        public TestClass()
        {
                Console.WriteLine("Stating");
            List<Product> listWantedProducts = new List<Product>();
            List<Location> listLocations = new List<Location>();
            listWantedProducts.Add(AddProduct(2, "TV", 2, 150));
            listWantedProducts.Add(AddProduct(3, "Radio", 10, 9));
            listLocations.Add(AddLocation("Danmark", "Esbjerg"));
            listLocations.Add(AddLocation("Tyskland", "München"));
            listLocations.Add(AddLocation("Norge", "Oslo"));

            while (true)
                {
                    Console.WriteLine("" +
                        "1 = Simulation Of Buying\n" +
                        "2 = Show Kvitering\n" +
                        "3 = Clear Console\n" +
                        "4 = Show OutPut From WareHouseConegtion.GetProdukts\n" +
                        "");
                    string Text = Console.ReadLine();
                    switch (Text)
                    {
                        case "1":
                        //This is Location
                        Console.WriteLine("Choose a location");
                        int num = 0;
                        foreach (var locatio in listLocations)
                        {
                            Console.WriteLine("num = " + num + " Country = " + locatio.Country + " Municipality = " + locatio.Municipality);
                            num++;
                        }
                        Location ShippingAdress = listLocations[GetAmount()];

                        //this is making a list of wanted products
                        List<Product> listofProducts = new List<Product>();
                        listofProducts.AddRange(listWantedProducts);
                        listWantedProducts.Clear();
                        num = 0;
                        int ChossenNum = 0;
                        while (ChossenNum != -1)
                        {
                            Console.WriteLine("Type (-1) when you are done with choosing");
                            num = 0;
                            foreach (var Products in listofProducts)
                            {
                                Console.WriteLine("num = " + num + " Name = " + Products.Name);
                                num++;
                            }
                            ChossenNum = GetAmount();
                            if (ChossenNum != -1)
                            {
                                Product CP = listofProducts[ChossenNum];
                                Console.WriteLine("how many do you want");
                                CP.Quantity = GetAmount();
                                CP.Location = ShippingAdress;
                                listWantedProducts.Add(CP);
                            }
                            Console.WriteLine("Product Have Been Add Your Corent have = " + listWantedProducts.Count + " Difrent Wares");
                        }
                        Console.WriteLine("now Have order Been Made");
                        // this is getting a the products from the warehouse controller
                        //WareHouseCongtion Part
                        //    List<List<Product>> WareHouseStuff(List<Product>);
                        List<List<Product>> BougthProduckts = new WareHouseConegtion().GetProdukts(new List<Product>());
                        //this is Show Kvitering Part
                        foreach (var ListOFProducts in BougthProduckts)
                        {
                            Console.WriteLine(ListOFProducts[0].Name);
                            foreach (var item in ListOFProducts)
                            {
                                Console.WriteLine("    Name = " + item.Name + "   Quantity = " + item.Quantity);
                            }
                        }
                        break;
                        case "2": //Show Kvitering
                            Console.WriteLine("You Hae Chossen Show Kvitering");
                            Receipt receipt = new Payment().MakeReceipt();
                            Console.WriteLine("price" + receipt.price);
                            Console.WriteLine("shippingPrice" + receipt.shippingPrice);
                            Console.WriteLine("time" + receipt.time);
                            foreach (var ListOFProducts in receipt.listOFListOFProducts)
                            {
                                Console.WriteLine(ListOFProducts[0].Name);
                                foreach (var item in ListOFProducts)
                                {
                                    Console.WriteLine("     "+item.Name);
                                }
                            }
                            break;
                        case "3":
                            Console.Clear();
                            break;
                        case "4":
                        
                        foreach (var ListOFProducts in new WareHouseConegtion().GetProdukts(new List<Product>() { new Product() { Name = "This is a Test a Test" } }))
                        {
                            Console.WriteLine(ListOFProducts[0].Name);
                            foreach (var item in ListOFProducts)
                            {
                                Console.WriteLine("    Name = " + item.Name + "   Quantity = " + item.Quantity);
                            }
                        }
                        break;
                    default:
                            break;
                    }
                    Console.WriteLine(Text);
                }
        }

        private int GetAmount()
        {
            int amount = -1;
            bool amountCheck = false;
            while (amountCheck == false)
            {
                if (Int32.TryParse(Console.ReadLine(), out amount))
                    amountCheck = true;
                else
                    Console.WriteLine("String could not be parsed. Plz use numbers");
            }
            return amount;
        }
    }
}
