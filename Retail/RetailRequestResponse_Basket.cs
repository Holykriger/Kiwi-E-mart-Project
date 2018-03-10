using EasyNetQ;
using ShoppingSystem_Entities;
using ShoppingSystem_Entities.HTTPRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Basket;

namespace Retail
{
    public class RetailRequestResponse_Basket
    {
        public static HTTPRequest_RetailerToClientGateway AttemptToAddProduct(HTTPRequest_ClientToGateway request)
        {
            Cookie userCookie = request.Cookie;
            Console.WriteLine("Checkin if user string is valid, info received - USERACCOUNTSTRING: "+ userCookie.CurrentCookieString);
            //Todo: remember to verify password and not just username.
            if (Cookie.ServerCheckIsValidUserString(userCookie.CurrentCookieString))
            {
                if (request.Product == null)
                {
                    Console.WriteLine("Product is null before adding");
                }
                Console.WriteLine("Valid user account string, adding product to basket.");
                HTTPRequest_RetailerToClientGateway response = new HTTPRequest_RetailerToClientGateway();
                #region Add product to basket + construct response with new basket.
                //Add to basket
                response.Basket = BasketManager.Singleton().AddObjectToUserBasket(userCookie.CurrentCookieString, request.Product);
                //Response
                response.Cookie = userCookie;
                foreach (var product in response.Basket.ShowContent)
                {
                    if (product == null)
                    {
                        Console.WriteLine("Product is null");
                    }
                    else
                    {
                        Console.WriteLine("Product: "+product.Name);
                    }
                }
                #endregion
                return response;
            }
            else
            {
                Console.WriteLine("User account string could not be verified.");
                return null;
            }
        }
    }
}
