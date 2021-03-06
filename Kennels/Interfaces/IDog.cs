﻿using System.Collections.Generic;
using System.Drawing;

namespace Kennels.Interfaces
{
    interface IDog
    {
        Dog AddDog(string name, int age, User createdBy, bool isMale, Image img, Owner owner, DogBreed breed);

        bool DeleteDog(Dog dog);

        void UpdateDog(Dog dog, string name, int age, bool isMale, Owner owner, DogBreed breed);

        List<Dog> GetAllDogs();

        List<Dog> GetAllActiveDogs();

        List<Dog> GetAllDeletedDogs();

        List<Dog> GetAllDogsByOwner(Owner owner);

        List<Dog> GetAllActiveDogsByOwner(Owner owner);

        List<Dog> GetAllDeketedDogsByOwner(Owner owner);
    }
}
