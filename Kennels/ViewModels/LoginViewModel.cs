using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class LoginViewModel : ILogin
    {
        public User LoginUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Username not specified.");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password not specified.");

            using (KennelsModelContainer context = new KennelsModelContainer())
            {
                User usr = context.Users.Where(u => u.Name.Equals(username)).FirstOrDefault();

                if (usr != null)
                {
                    if (usr.Password.Equals(password))
                        return usr;
                    else
                        throw new InvalidOperationException("User Password is incorrect.");
                }
                else
                    throw new InvalidOperationException("User not found.");
            }
        }
    }
}
