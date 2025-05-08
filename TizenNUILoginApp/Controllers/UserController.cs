using System;
using System.Collections.Generic;
using TizenNUILoginApp.Models;

namespace TizenNUILoginApp.Controllers
{
    public class UserController
    {
        private static List<User> users = new List<User>
        {
            new User { Email = "admin", Password = "password" } // Default user for testing
        };

        public bool ValidateLogin(string email, string password)
        {
            return users.Exists(u => u.Email == email && u.Password == password);
        }

        public bool RegisterUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                return false;

            if (users.Exists(u => u.Email == user.Email))
                return false;

            users.Add(user);
            return true;
        }

        public User GetUserByEmail(string email)
        {
            return users.Find(u => u.Email == email);
        }
    }
}
