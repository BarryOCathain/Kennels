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
            return _context.Animals.Where(a => a.IsObsolete == false).ToList();
        }

        public List<Animal> GetAllAnimals()
        {
            return _context.Animals.ToList();
        }

        public List<Animal> GetAllDeletedAnimals()
        {
            return _context.Animals.Where(a => a.IsObsolete == true).ToList();
        }
    }
}
