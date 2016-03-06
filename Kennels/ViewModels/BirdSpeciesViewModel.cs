using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class BirdSpeciesViewModel : IBirdSpecies
    {
        KennelsModelContainer _context;

        public BirdSpeciesViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public BirdSpecies AddBirdSpecies(string name, User createdBy)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Bird Species Name not specified.");

            if (createdBy == null)
                throw new ArgumentException("New Bird Species Created By User not specified.");

            BirdSpecies b = new BirdSpecies
            {
                Name = name,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now
            };

            try
            {
                _context.BirdSpecies.Add(b);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return b;
        }

        public bool DeleteBirdSpecies(BirdSpecies birdSpecies)
        {
            if (birdSpecies == null)
                throw new ArgumentException("Bird Species to be deleted Name not specified.");

            try
            {
                BirdSpecies bs = _context.BirdSpecies.Where(b => b.Equals(birdSpecies)).FirstOrDefault();

                bs.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<BirdSpecies> GetAllActiveBirdSpecies()
        {
            try
            {
                return _context.BirdSpecies.Where(b => b.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Bird> GetAllBirdsByBirdSpecies(BirdSpecies birdSpecies)
        {
            if (birdSpecies == null)
                throw new ArgumentException("Birds requested Bird Species not specified.");

            try
            {
                return _context.Animals.OfType<Bird>().Where(b => b.BirdSpecy.Equals(birdSpecies)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<BirdSpecies> GetAllBirdSpecies()
        {
            try
            {
                return _context.BirdSpecies.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<BirdSpecies> GetAllDeletedBirdSpecies()
        {
            try
            {
                return _context.BirdSpecies.Where(b => b.IsObsolete == true).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateBirdSpecies(BirdSpecies birdSpecies, string name)
        {
            if (birdSpecies == null)
                throw new ArgumentException("Bird Species to be updated not specified.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Bird Species to be updated Name not specified.");

            try
            {
                BirdSpecies bs = _context.BirdSpecies.Where(b => b.Equals(birdSpecies)).FirstOrDefault();

                bs.Name = name;

                _context.SaveChanges();
            }
            catch (Exception) { }
        }
    }
}
