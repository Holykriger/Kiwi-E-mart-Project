using EasyNetQ;
using ShoppingSystem_Entities;
using ShoppingSystem_Entities.HTTPRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Basket;
using EasyNetQ.Topology;

namespace Retail
{
    public class RetailRequestResponse_Login
    {
        public static HTTPRequest_RetailerToClientGateway AttemptLogin(HTTPRequest_ClientToGateway request)
        {
            User user = request.User;
            Console.WriteLine("Checkin if user is valid, info received - USERNAME: "+ user.userName + " PASSWORD: " +user.password);
            //Todo: remember to verify password and not just username.

            HTTPRequest_RetailerToClientGateway response = new HTTPRequest_RetailerToClientGateway();
            if (User.VerifyUserCredentials(user))
            {
                Console.WriteLine("Valid user, sending verification cookie.");
                Cookie cookie = new Cookie(); 
                cookie.CurrentCookieString = GetUserAccountString(user.userName);
                #region Create HTTP response
                
                response.Cookie = cookie;
                //response.Basket = BasketManager.Singleton().GetUserBasket(request.Cookie.CurrentCookieString);
                //if (response.Basket == null)
                //{
                //    response.Basket = new Baskets();
                //}
                response.Products = RetailRequestResponse_ViewProducts.getTestProductList();
                #endregion
            }
            else
            {
                Cookie cookie = new Cookie();
                cookie.CurrentCookieString = "NotLoggedIn";
                response.Cookie = cookie;
                Console.WriteLine("User could not be verified.");
            }
            return response;
        }

        public static string GetUserAccountString(string userName) {
            string accountString = "NotLoggedIn";
            switch (userName)
            {
                case "Dennis":
                    accountString = "Dennis123";
                    break;
                case "Martin":
                    accountString = "Martin123";
                    break;
                case "Simon":
                    accountString = "Simon123";
                    break;
                case "Alex":
                    accountString = "Alex123";
                    break;
                default:
                    accountString = "NotValidUser";
                    break;
            }
            return accountString;
        }
    }
}
