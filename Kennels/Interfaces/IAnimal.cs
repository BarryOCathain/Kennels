using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IAnimal
    {
        List<Animal> GetAllAnimals();

        List<Animal> GetAllActiveAnimals();

        List<Animal> GetAllDeletedAnimals();
    }
}
