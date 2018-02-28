using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSystem_Entities
{
    public class User
    {
        public static List<User> UserList { get; set; } = new List<User>() {
            new User("Dennis", "DennisPW"),
            new User("Martin", "MartinPW"),
            new User("Simon", "SimonPW"),
            new User("Alex", "AlexPW") };

        public User(string userName, string password) {
            this.userName = userName;
            this.password = password;
        }

        public static bool VerifyUserCredentials(User loginInfo) {
            foreach (var user in UserList)
            {
                if (user.userName.Equals(loginInfo.userName) && user.password.Equals(loginInfo.password))
                return true;
            }
            return false;
        }

        public string userName { get; private set; } = "no user";
        public string password { get; private set; } = "no password";
    }
    
}
