﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;
using System.Drawing;
using Kennels.Common;
using Kennels.Properties;

namespace Kennels.ViewModels
{
    class BirdViewModel : IBird
    {
        KennelsModelContainer _context;

        public BirdViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Bird AddBird(string name, int age, BirdSpecies species, User createdBy, bool isMale, Image img, Owner owner)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Bird Name not specified.");

            if (age < 1)
                throw new ArgumentException("New Bird Age cannot be less than 1.");

            if (species == null)
                throw new ArgumentException("New Bird Species not specified.");

            if (createdBy == null)
                throw new ArgumentException("New Bird Created By User not specified.");

            if (owner == null)
                throw new ArgumentException("New Bird Owner not specified.");

            Bird b = new Bird
            {
                Name = name,
                Age = age,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now,
                IsMale = isMale,
                Image = CommonUtilities.ImageToByteArray(img == null ? Resources.NoImage : img),
                Owner = owner,
                BirdSpecy = species
            };

            try
            {
                _context.Animals.Add(b);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return b;
        }

        public bool DeleteBird(Bird bird)
        {
            if (bird == null)
                throw new ArgumentException("Bird to be deleted not specified.");

            try
            {
                Bird bd = _context.Animals.OfType<Bird>().Where(b => b.Equals(bird)).FirstOrDefault();

                bd.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public List<Bird> GetAllActiveBirds()
        {
            return _context.Animals.OfType<Bird>().Where(b => b.IsObsolete == false).ToList();
        }

        public List<Bird> GetAllBirds()
        {
            return _context.Animals.OfType<Bird>().ToList();
        }

        public List<Bird> GetAllBirdsByOwner(Owner owner)
        {
            if (owner == null)
                throw new ArgumentException("Birds requested Owner not specified.");

            try
            {
                return _context.Animals.OfType<Bird>().Where(b => b.Owner.Equals(owner)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Bird> GetAllDeletedBirds()
        {
            return _context.Animals.OfType<Bird>().Where(b => b.IsObsolete == true).ToList();
        }

        public void UpdateBird(Bird bird, string name, int age, bool isMale, Owner owner)
        {
            if (bird == null)
                throw new ArgumentException("Bird to be updated not specified.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Bird to be updated Name not specified.");

            if (age < 1)
                throw new ArgumentException("Bird to be updated Age cannot be less than 1.");

            if (owner == null)
                throw new ArgumentException("Bird to be updated Owner not specified.");

            try
            {
                Bird bd = _context.Animals.OfType<Bird>().Where(b => b.Equals(bird)).FirstOrDefault();

                bd.Name = name;
                bd.Age = age;
                bd.IsMale = isMale;
                bd.Owner = owner;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
