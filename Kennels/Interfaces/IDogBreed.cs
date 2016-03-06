using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IDogBreed
    {
        DogBreed AddDogBreed(string name, User createdBy);

        bool DeleteDogBreed(DogBreed dogBreed);

        void UpdateDogBreed(DogBreed dogBreed, string name);

        List<DogBreed> GetAllDogBreeds();

        List<DogBreed> GetAllActiveDogBreeds();

        List<DogBreed> GetAllDeletedDogBreeds();
    }
}
