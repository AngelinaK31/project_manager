using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerApp.Classes
{
    public class Authorization
    {
        public static bool LogIn(string login, string password, List<Entities.User> users, out Entities.User currentUser)
        {
            currentUser = null;

            foreach (var user in users)
            {
                if (user.Login == login && user.Passwrord == password)
                {
                    currentUser = user;
                    return true;

                }
            }
            return false;
        }
    }
}
