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
                throw;
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
                throw;
            }
            return true;
        }

        public List<DogBreed> GetAllActiveDogBreeds()
        {
            return _context.DogBreeds.Where(d => d.IsObsolete == false).ToList();
        }

        public List<DogBreed> GetAllDeletedDogBreeds()
        {
            return _context.DogBreeds.Where(d => d.IsObsolete == true).ToList();
        }

        public List<DogBreed> GetAllDogBreeds()
        {
            return _context.DogBreeds.ToList();
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
