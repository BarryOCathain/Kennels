using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IUser
    {
        User AddUser(string name, string password, User createdBy, bool isAdmin);

        bool DeleteUser(User user);

        void ToggleUserAdmin(User adminUser, User user);

        void ChangeUserPassword(User user, string newPassword);

        List<User> GetAllUsers();

        User GetUserByName(string name);
    }
}
