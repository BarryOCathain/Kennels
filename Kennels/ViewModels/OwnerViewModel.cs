using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class OwnerViewModel : IOwner
    {
        private KennelsModelContainer _context;

        public OwnerViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Owner AddOwner(string firstName, string surname, string propNameNum, string add1, string add2, string add3,
            string postcode, string phone1, string phone2, string email, User createdBy)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("New Owner First Name not specified.");

            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException("New Owner Surname not specified.");

            if (string.IsNullOrEmpty(propNameNum))
                throw new ArgumentException("New Owner Property Name or Number not specified.");

            if (string.IsNullOrEmpty(add1))
                throw new ArgumentException("New Owner Address Line 1 not specified.");

            if (string.IsNullOrEmpty(postcode))
                throw new ArgumentException("New Owner Postcode not specified.");

            if (string.IsNullOrEmpty(phone1))
                throw new ArgumentException("New Owner Primary Phone Number not specified.");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("New Owner Email not specified.");

            if (createdBy == null)
                throw new ArgumentException("New Owner Created By User not specified.");

            Owner o = new Owner
            {
                FirstName = firstName,
                Surname = surname,
                PropertyNameNumber = propNameNum,
                Address1 = add1,
                Address2 = add2 == null ? "" : add2,
                Address3 = add3 == null ? "" : add3,
                Postcode = postcode,
                Phone1 = phone1,
                Phone2 = phone2 == null ? "" : phone2,
                Email = email,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now
            };

            try
            {
                _context.Owners.Add(o);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return o;
        }

        public bool DeleteOwner(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Owner to be deleted not specified.");

            try
            {
                Owner ownr = _context.Owners.Where(o => o.Equals(owner)).FirstOrDefault();

                ownr.IsObsolete = true;

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Owner> GetAllOwners()
        {
            return _context.Owners.ToList();
        }

        public List<Animal> GetOwnerAnimals(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Owner of the requested Animals not specified.");

            try
            {
                return _context.Animals.Where(o => o.Owner.Equals(owner)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Booking> GetOwnerBookings(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Owner of the requested Bookings not specified.");

            try
            {
                return _context.Bookings.Where(o => o.Owner.Equals(owner)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Owner> GetOwnersByFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("First Name of the requested Owners not specified.");

            try
            {
                return _context.Owners.Where(o => o.FirstName.Equals(firstName)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Owner> GetOwnersBySurname(string surname)
        {
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException("Surname of the requested Owners not specified.");

            try
            {
                return _context.Owners.Where(o => o.Surname.Equals(surname)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateOwner(Owner owner, string firstName, string surname, string propNameNum, string add1, string add2, string add3,
            string postcode, string phone1, string phone2, string email)
        {
            if (owner == null)
                throw new ArgumentException("Owner to be updated not specified.");

            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("New Owner First Name not specified.");

            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException("New Owner Surname not specified.");

            if (string.IsNullOrEmpty(propNameNum))
                throw new ArgumentException("New Owner Property Name or Number not specified.");

            if (string.IsNullOrEmpty(add1))
                throw new ArgumentException("New Owner Address Line 1 not specified.");

            if (string.IsNullOrEmpty(postcode))
                throw new ArgumentException("New Owner Postcode not specified.");

            if (string.IsNullOrEmpty(phone1))
                throw new ArgumentException("New Owner Primary Phone Number not specified.");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("New Owner Email not specified.");

            try
            {
                Owner ownr = _context.Owners.Where(o => o.Equals(owner)).FirstOrDefault();

                ownr.FirstName = firstName;
                ownr.Surname = surname;
                ownr.PropertyNameNumber = propNameNum;
                ownr.Address1 = add1;
                ownr.Address2 = add2 == null ? "" : add2;
                ownr.Address3 = add3 == null ? "" : add3;
                ownr.Postcode = postcode;
                ownr.Phone1 = phone1;
                ownr.Phone2 = phone2 == null ? "" : phone2;
                ownr.Email = email;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
