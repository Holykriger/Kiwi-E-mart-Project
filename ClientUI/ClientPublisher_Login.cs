using EasyNetQ;
using ShoppingSystem_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientUI
{
    class ClientPublisher_Login
    {

        public static void AttemptLogin(string userName, string password) {
            Publish(userName, password);
            bool LoggedInSuccesfully = ClientSubscriber_Login.AwaitLoginReply(); //Needs to be made async, possibly with tasks. Also need to split Cookie into 2 parts so client and retail don't both listen for cookies. Client when verifying user login and retail when confirming that user is logged in. Can perhaps make a "ConfirmIsLoggedIn" class which holds a cookie.
        }

        public static void Publish(string userName, string password)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                Console.WriteLine("Attempting to log in with USERNAME: "+ userName + " and PASSWORD: "+password ); //Showing password for debugging.
                bus.Publish(new User(userName, password));
            }
        }
    }
}
