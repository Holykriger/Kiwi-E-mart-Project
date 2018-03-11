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
    public class RetailRequestResponse_ViewProducts
    {
        private static bool _RequiresLogin = false;

        public static HTTPRequest_RetailerToClientGateway AttemptToViewProducts(HTTPRequest_ClientToGateway request)
        {
            Cookie userCookie = request.Cookie;
            Console.WriteLine("Checkin if user string is valid, info received - USERACCOUNTSTRING: "+ userCookie.CurrentCookieString);
            //Todo: remember to verify password and not just username.
            HTTPRequest_RetailerToClientGateway response = new HTTPRequest_RetailerToClientGateway();
            response.Cookie = userCookie;
            if (_RequiresLogin == false || Cookie.ServerCheckIsValidUserString(userCookie.CurrentCookieString)) //If doesn't require login or login is verifiable.
            {
                Console.WriteLine("Valid user account string, responding with product list.");
                #region Construct response with list of products.
                response.Products = getTestProductList();
                #endregion
                return response;
            }
            else
            {
                Console.WriteLine("User account string could not be verified.");
                return response;
            }

        }

        public static List<Product> getTestProductList()
        {
            Location location = new Location() { Country = "Denmark", Area = 500, Municipality = "Esbjerg" };
            return new List<Product>() {
                    new Product(){ ID = 1, Description = "description1", Name = " Banana", Quantity = 1, Price = 50, Location = location },
                    new Product(){ ID = 2, Description = "description2", Name = " Phone", Quantity = 2, Price = 500, Location = location },
                    new Product(){ ID = 3, Description = "description3", Name = " Bed", Quantity = 3, Price = 5000, Location = location } };
        }
    }
}
