using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class HamsterViewModel : IHamster
    {
        KennelsModelContainer _context;

        public HamsterViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Hamster AddHamster(string name, int age, User createdBy, bool isMale, Owner owner)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Hamster Name not specified.");

            if (age < 1)
                throw new ArgumentException("New Hamster age cannot be less than 1.");

            if (createdBy == null)
                throw new ArgumentException("New Hamster Created By User not specified.");

            if (owner == null)
                throw new ArgumentException("New Hamster Owner not specified,");

            Hamster h = new Hamster
            {
                Name = name,
                Age = age,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now,
                IsMale = isMale,
                Owner = owner
            };

            try
            {
                _context.Animals.Add(h);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return h;
        }

        public bool DeleteHamster(Hamster hamster)
        {
            if (hamster == null)
                throw new ArgumentException("Hamster to be deleted not specified.");

            try
            {
                Hamster hr = _context.Animals.OfType<Hamster>().Where(h => h.Equals(hamster)).FirstOrDefault();

                hr.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Hamster> GetAllActiveHamsters()
        {
            try
            {
                return _context.Animals.OfType<Hamster>().Where(h => h.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Hamster> GetAllActiveHamstersByOwner(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Hamsters requested Owner not speicified.");

            try
            {
                return _context.Animals.OfType<Hamster>().Where(h => h.Owner.Equals(owner) && h.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Hamster> GetAllDeletedHamsters()
        {
            try
            {
                return _context.Animals.OfType<Hamster>().Where(h => h.IsObsolete == true).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Hamster> GetAllDeletedHamstersByOwner(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Hamsters requested Owner not speicified.");

            try
            {
                return _context.Animals.OfType<Hamster>().Where(h => h.Owner.Equals(owner) && h.IsObsolete == true).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Hamster> GetAllHamsters()
        {
            try
            {
                return _context.Animals.OfType<Hamster>().ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Hamster> GetAllHamstersByOwner(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Hamsters requested Owner not speicified.");

            try
            {
                return _context.Animals.OfType<Hamster>().Where(h => h.Owner.Equals(owner) && h.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateHamster(Hamster hamster, string name, int age, bool isMale, Owner owner)
        {
            if (hamster == null)
                throw new ArgumentException("Hamster to be updated not specified.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Hamster to be updated Name not specified.");

            if (age < 1)
                throw new ArgumentException("Hamster to be updated age cannot be less than 1.");

            if (owner == null)
                throw new ArgumentException("Hamster to be updated Owner not specified.");

            try
            {
                Hamster hr = _context.Animals.OfType<Hamster>().Where(h => h.Equals(hamster)).FirstOrDefault();

                if (hr != null)
                {
                    hr.Name = name;
                    hr.Age = age;
                    hr.IsMale = isMale;
                    hr.Owner = owner;

                    _context.SaveChanges();
                }
                else
                    throw new InvalidOperationException("Hamster to be updated not found.");
            }
            catch (Exception) { }
        }
    }
}
