using System.Collections.Generic;
using System.Drawing;

namespace Kennels.Interfaces
{
    interface IBird
    {
        Bird AddBird(string name, int age, BirdSpecies species, User createdBy, bool isMale, Image img, Owner owner);

        bool DeleteBird(Bird bird);

        void UpdateBird(Bird bird, string name, int age, bool isMale, Owner owner);

        List<Bird> GetAllBirds();

        List<Bird> GetAllActiveBirds();

        List<Bird> GetAllDeletedBirds();

        List<Bird> GetAllBirdsByOwner(Owner owner);
    }
}
