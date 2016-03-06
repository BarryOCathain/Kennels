using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class CatViewModel : ICat
    {
        KennelsModelContainer _context;

        public CatViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Cat AddCat(string name, int age, User createdBy, bool isMale, Owner owner)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Cat Name not specified.");

            if (age < 1)
                throw new ArgumentException("New Cat Age muzst be at least 1.");

            if (createdBy == null)
                throw new ArgumentException("New Cat Created By User not specified.");

            if (owner == null)
                throw new ArgumentException("New Cat Owner not specified.");

            Cat c = new Cat
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
                _context.Animals.Add(c);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return c;

        }

        public bool DeleteCat(Cat cat)
        {
            if (cat == null)
                throw new ArgumentException("Cat to be deleted not specified.");

            try
            {
                Cat ct = _context.Animals.OfType<Cat>().Where(c => c.Equals(cat)).FirstOrDefault();

                ct.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Cat> GetAllActiveCats()
        {
            try
            {
                return _context.Animals.OfType<Cat>().Where(c => c.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cat> GetAllCats()
        {
            try
            {
                return _context.Animals.OfType<Cat>().ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cat> GetAllDeletedCats()
        {
            try
            {
                return _context.Animals.OfType<Cat>().Where(c => c.IsObsolete == true).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateCat(Cat cat, string name, int age, bool isMale, Owner owner)
        {
            if (cat == null)
                throw new ArgumentException("Cat to be updated not specified,");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Cat to be updated Name not specified.");

            if (age < 1)
                throw new ArgumentException("Cat to be updated Age cannot be less than 1.");

            if (owner == null)
                throw new ArgumentException("Cat to be updated Owner not specified.");

            try
            {
                Cat ct = _context.Animals.OfType<Cat>().Where(c => c.Equals(cat)).FirstOrDefault();

                ct.Name = name;
                ct.Age = age;
                ct.IsMale = isMale;
                ct.Owner = owner;

                _context.SaveChanges();
            }
            catch (Exception) { }
        }
    }
}
