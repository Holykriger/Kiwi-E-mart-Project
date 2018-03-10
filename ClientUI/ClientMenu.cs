using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingSystem_Entities.HTTPRequests;
using Basket;

namespace ClientUI
{
    class ClientMenu
    {
        bool programRunning = true;
        public ClientMenu() {
            var input = "";
            while (programRunning)
            {
                DisplayMenuOption();
                input = Console.ReadLine();
                MenuOptions(input);
            }
        }

        void DisplayMenuOption() {
            Console.WriteLine("Welcome to Kwik-E-Mart.");
            Console.WriteLine("- - - - - - - Menu - - - - - - - -");
            Console.WriteLine("Please make a selection in the menu by entering a command and pressing the >ENTER< key.");
            Console.WriteLine("");
            Console.WriteLine("Available commands:");
            Console.WriteLine("LOGIN");
            //Console.WriteLine("REGISTER USER");
            if (ClientRequestResponse_Login.IsLoggedIn())
            {
                Console.WriteLine("DISPLAY BASKET");
                Console.WriteLine("SEE PRODUCTS");
                Console.WriteLine("ADD PRODUCT");
                Console.WriteLine("LOG OUT");
            }
            Console.WriteLine("QUIT");
            Console.WriteLine("");
        }

        void MenuOptions(string command)
        {
            switch (command.ToLower())
            {
                case "login":
                    Login();
                    break;
                case "register user":
                    break;
                case "display basket":
                    DisplayBasket();
                    break;
                case "see products":
                    ViewProducts();
                    break;
                case "add product":
                    AddProduct();
                    break;
                case "log out":
                    LogOut();
                    break;
                case "quit":
                    programRunning = false;
                    break;
                default:
                    break;
            }
        }

        private void Login()
        {
            string userName = "";
            string password = "";
            Console.WriteLine("Username: ");
            userName = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();
            HTTPRequest_ClientToGateway requestLogin = new HTTPRequest_ClientToGateway();
            #region Request setup
            requestLogin.RetailCmd = HTTPRequest_ClientToGateway.RetailCommand.Login;
            requestLogin.User = new User(userName, password);
            #endregion
            ClientRequestResponse.SendRequest(requestLogin);
        }

        private void DisplayBasket()
        {
            if (!ClientRequestResponse_Login.IsLoggedIn())
            {
                Console.WriteLine("ERROR - Not logged in.");
                return;
            }
            if (ClientSession.Basket == null)
            {
                Console.WriteLine("Cannot display basket, it is null.");
                return;
            }
            ClientSession.Basket.DisplayBasket();
        }

        private void ViewProducts()
        {
            //Display a list of products for the user. Inform them they must log in to access the shop.
            HTTPRequest_ClientToGateway requestViewProducts = new HTTPRequest_ClientToGateway();
            #region Request setup
            requestViewProducts.RetailCmd = HTTPRequest_ClientToGateway.RetailCommand.ViewAllProducts;
            requestViewProducts.Cookie = ClientSession.ClientCookie;
            #endregion
            ClientRequestResponse.SendRequest(requestViewProducts);
        }

        private void AddProduct()
        {
            if (!ClientRequestResponse_Login.IsLoggedIn())
            {
                Console.WriteLine("ERROR - Not logged in.");
                return;
            }

            int productIDAsInt = -1;
            Console.WriteLine("Product ID: ");
            string productID = Console.ReadLine();
            if (!int.TryParse(productID, out productIDAsInt))
            {
                Console.WriteLine("ERROR - not a number.");
            }
            Console.WriteLine("Quantity: ");
            string quantity = Console.ReadLine();
            int quantityAsInt = -1;
            if (!int.TryParse(quantity, out quantityAsInt))
            {
                Console.WriteLine("ERROR - not a number.");
            }
            Product p = ClientSession.CurrentProductListDisplayed.FirstOrDefault(x => x.ID == productIDAsInt);
            if (p == null)
            {
                Console.WriteLine("Invalid product ID. Please update products list by typing 'see products' in the main menu.");
                return;
            }
            p.Quantity = quantityAsInt;
            //Request
            HTTPRequest_ClientToGateway requestAddProduct = new HTTPRequest_ClientToGateway();
            #region Request setup
            requestAddProduct.Product = p;
            requestAddProduct.Cookie = ClientSession.ClientCookie;
            requestAddProduct.RetailCmd = HTTPRequest_ClientToGateway.RetailCommand.AddProduct;
            #endregion
            ClientRequestResponse.SendRequest(requestAddProduct);
        }

        private void LogOut()
        {
            if (!ClientRequestResponse_Login.IsLoggedIn())
            {
                Console.WriteLine("Was already not logged in.");
                return;
            }
            Client_Logout.LogOut();
        }
    }

}
