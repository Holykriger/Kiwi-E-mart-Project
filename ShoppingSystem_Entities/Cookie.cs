using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSystem_Entities
{
    public class Cookie
    {
        public static List<string> UserAccountStrings { get; set; } = new List<string>() { "Dennis123", "Martin123", "Simon123", "Alex123" };

        public static bool ServerCheckIsValidUserString(string userString)
        {
            return UserAccountStrings.Contains(userString);
        }

        public static bool ClientCheckIsValidUserString(string userString)
        {
            return !userString.Equals("NotLoggedIn");
        }

        public string CurrentCookieString { get; set; } = "NotLoggedIn";

    }
}
