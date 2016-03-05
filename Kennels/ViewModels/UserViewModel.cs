using Kennels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.ViewModels
{
    class UserViewModel : IUser
    {
        private KennelsModelContainer _context;

        public UserViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public User AddUser(string name, string password, User createdBy, bool isAdmin)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New User name not specified.");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("New User password not specified.");

            if (createdBy == null)
                throw new ArgumentException("New User Created By User not specified.");

            User u = new User
            {
                Name = name,
                Password = password,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now,
                IsAdmin = isAdmin
            };

            try
            {
                _context.Users.Add(u);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return u;
        }

        public void ChangeUserPassword(User user, string newPassword)
        {
            if (user == null)
                throw new ArgumentException("User to have password updated not specified.");

            if (string.IsNullOrEmpty(newPassword))
                throw new ArgumentException("New Password not specified.");

            if (newPassword.Equals(user.Password))
                throw new ArgumentException("New and Old Passwords are the same.");

            try
            {
                User usr = _context.Users.Where(u => u.UserID == user.UserID).FirstOrDefault();

                usr.Password = newPassword;

                _context.SaveChanges();
            }
            catch (Exception) { }
        }

        public bool DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentException("User to be deleted not specified.");

            try
            {
                User usr = _context.Users.Where(u => u.UserID == user.UserID).FirstOrDefault();

                usr.IsObsolete = true;

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User GetUserByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("User name not specified.");

            try
            {
                return _context.Users.Where(u => u.Name.Equals(name)).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ToggleUserAdmin(User adminUser, User user)
        {
            if (adminUser == null)
                throw new ArgumentException("Admin User not specified.");

            if (!adminUser.IsAdmin)
                throw new ArgumentException("Admin User specified does not have permission.");

            if (user == null)
                throw new ArgumentException("User to be mande Admin not specified.");

            try
            {
                User usr = _context.Users.Where(u => u.UserID == user.UserID).FirstOrDefault();

                usr.IsAdmin = true;

                _context.SaveChanges();
            }
            catch (Exception) { }
        }
    }
}
