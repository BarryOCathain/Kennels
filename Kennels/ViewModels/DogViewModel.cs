using System;
using System.Collections.Generic;
using System.Linq;
using Kennels.Interfaces;
using System.Drawing;
using Kennels.Common;
using Kennels.Properties;

namespace Kennels.ViewModels
{
    class DogViewModel : IDog
    {
        KennelsModelContainer _context;

        public DogViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Dog AddDog(string name, int age, User createdBy, bool isMale, Image img, Owner owner, DogBreed breed)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Dog Name not specified.");

            if (age < 1)
                throw new ArgumentException("New Dog Age cannot be less than 1.");

            if (createdBy == null)
                throw new ArgumentException("New Dog Created By User not specified.");

            if (owner == null)
                throw new ArgumentException("New Dog Owner not specified.");

            if (breed == null)
                throw new ArgumentException("New DOg Owner not specified.");

            Dog d = new Dog
            {
                Name = name,
                Age = age,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now,
                IsMale = isMale,
                Image = CommonUtilities.ImageToByteArray(img == null ? Resources.NoImage : img),
                Owner = owner,
                DogBreed = breed
            };

            try
            {
                _context.Animals.Add(d);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return d;
        }

        public bool DeleteDog(Dog dog)
        {
            if (dog == null)
                throw new ArgumentException("Dog to be deleted not specified.");

            try
            {
                Dog dg = _context.Animals.OfType<Dog>().Where(d => d.Equals(dog)).FirstOrDefault();

                dg.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public List<Dog> GetAllActiveDogs()
        {
            return _context.Animals.OfType<Dog>().Where(d => d.IsObsolete == false).ToList();
        }

        public List<Dog> GetAllActiveDogsByOwner(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Dogs requested Owner not specified.");

            try
            {
                return _context.Animals.OfType<Dog>().Where(d => d.Owner.Equals(owner) && d.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Dog> GetAllDeketedDogsByOwner(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Dogs requested Owner not specified.");

            try
            {
                return _context.Animals.OfType<Dog>().Where(d => d.Owner.Equals(owner) && d.IsObsolete == true).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Dog> GetAllDeletedDogs()
        {
            return _context.Animals.OfType<Dog>().Where(d => d.IsObsolete == false).ToList();
        }

        public List<Dog> GetAllDogs()
        {
            return _context.Animals.OfType<Dog>().ToList();
        }

        public List<Dog> GetAllDogsByOwner(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Dogs requested Owner not specified.");

            try
            {
                return _context.Animals.OfType<Dog>().Where(d => d.Owner.Equals(owner)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateDog(Dog dog, string name, int age, bool isMale, Owner owner, DogBreed breed)
        {
            if (dog == null)
                throw new ArgumentException("Dog to be updated not specified.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Dog to be updated Name not specified.");

            if (age < 1)
                throw new ArgumentException("Dog to be updated Agew cannot be less than 1.");

            if (owner == null)
                throw new ArgumentException("Dog to be updated Owner not specified.");

            if (breed == null)
                throw new ArgumentException("Dog to be updated Dog Breed not specified.");

            try
            {
                Dog dg = _context.Animals.OfType<Dog>().Where(d => d.Equals(dog)).FirstOrDefault();

                if (dg != null)
                {
                    dg.Name = name;
                    dg.Age = age;
                    dg.IsMale = isMale;
                    dg.Owner = owner;
                    dg.DogBreed = breed;

                    _context.SaveChanges();
                }
                else
                    throw new InvalidOperationException("Dog to be updated Not Found.");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
