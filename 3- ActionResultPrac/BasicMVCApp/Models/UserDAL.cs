using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicMVCApp.Models
{
    public class UserDAL
    {
        public static Boolean Verify(String login,String password)
        {
            if (login == "admin" && password == "admin")
                return true;
            else
                return false;
        }

        public static Boolean SaveUser(User obj)
        {
            return true;
        }

        public static List<User> GetAllUsers()
        {
            List<User> list = new List<User>();
            list.Add(new User()
            {
                username = "ABC1",
                company = "XYZ1",
                login = "login1",
                password = "password1"
            });
            list.Add(new User()
            {
                username = "ABC2",
                company = "XYZ2",
                login = "login2",
                password = "password2"
            });
            list.Add(new User()
            {
                username = "ABC3",
                company = "XYZ3",
                login = "login3",
                password = "password3"
            });

            return list;
        }
    }
}