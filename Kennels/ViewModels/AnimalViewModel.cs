using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class AnimalViewModel : IAnimal
    {
        KennelsModelContainer _context;

        public AnimalViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public List<Animal> GetAllActiveAnimals()
        {
            try
            {
                return _context.Animals.Where(a => a.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Animal> GetAllAnimals()
        {
            try
            {
                return _context.Animals.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Animal> GetAllDeletedAnimals()
        {
            try
            {
                return _context.Animals.Where(a => a.IsObsolete == true).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
