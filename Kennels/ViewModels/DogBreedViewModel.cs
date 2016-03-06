using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class DogBreedViewModel : IDogBreed
    {
        KennelsModelContainer _context;

        public DogBreedViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public DogBreed AddDogBreed(string name, User createdBy)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Dog Breed Name not specified.");

            if (createdBy == null)
                throw new ArgumentException("New Dog Breed Created By User not specified.");

            DogBreed db = new DogBreed
            {
                Name = name,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now
            };

            try
            {
                _context.DogBreeds.Add(db);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return db;
        }

        public bool DeleteDogBreed(DogBreed dogBreed)
        {
            if (dogBreed == null)
                throw new ArgumentException("Dog Breed to be deleted not specified.");

            try
            {
                DogBreed db = _context.DogBreeds.Where(d => d.Equals(dogBreed)).FirstOrDefault();

                db.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<DogBreed> GetAllActiveDogBreeds()
        {
            try
            {
                return _context.DogBreeds.Where(d => d.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DogBreed> GetAllDeletedDogBreeds()
        {
            try
            {
                return _context.DogBreeds.Where(d => d.IsObsolete == true).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DogBreed> GetAllDogBreeds()
        {
            try
            {
                return _context.DogBreeds.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateDogBreed(DogBreed dogBreed, string name)
        {
            if (dogBreed == null)
                throw new ArgumentException("Dog Breed to be updated not specified.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Dog Breed to be updated Name not specified.");

            try
            {
                DogBreed db = _context.DogBreeds.Where(d => d.Equals(dogBreed)).FirstOrDefault();

                db.Name = name;

                _context.SaveChanges();
            }
            catch (Exception) { }
        }
    }
}
