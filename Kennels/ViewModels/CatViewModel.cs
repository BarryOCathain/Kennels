using System;
using System.Collections.Generic;
using System.Linq;
using Kennels.Interfaces;
using System.Drawing;
using Kennels.Common;
using Kennels.Properties;

namespace Kennels.ViewModels
{
    class CatViewModel : ICat
    {
        KennelsModelContainer _context;

        public CatViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Cat AddCat(string name, int age, User createdBy, bool isMale, Image img, Owner owner)
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
                Image = CommonUtilities.ImageToByteArray(img == null ? Resources.NoImage : img),
                Owner = owner
            };

            try
            {
                _context.Animals.Add(c);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
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
                throw;
            }
            return true;
        }

        public List<Cat> GetAllActiveCats()
        {
            return _context.Animals.OfType<Cat>().Where(c => c.IsObsolete == false).ToList();
        }

        public List<Cat> GetAllCats()
        {
            return _context.Animals.OfType<Cat>().ToList();
        }

        public List<Cat> GetAllDeletedCats()
        {
            return _context.Animals.OfType<Cat>().Where(c => c.IsObsolete == true).ToList();
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
