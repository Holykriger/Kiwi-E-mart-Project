using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine("REGISTER USER");
            Console.WriteLine("SEE PRODUCTS");
            Console.WriteLine("QUIT");
            Console.WriteLine("");
        }

        void MenuOptions(string command)
        {
            switch (command.ToLower())
            {
                case "login":
                    string userName = "";
                    string password = "";
                    Console.WriteLine("Username: ");
                    userName = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    password = Console.ReadLine();
                    ClientPublisher_Login.AttemptLogin(userName, password);
                    break;
                case "register user":
                    break;
                case "see products":
                    //Display a list of products for the user. Inform them they must log in to access the shop.
                    break;
                case "quit":
                    programRunning = false;
                    break;
                default:
                    break;
            }
        }
    }

}
