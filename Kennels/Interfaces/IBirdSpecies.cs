using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IBirdSpecies
    {
        BirdSpecies AddBirdSpecies(string name, User createdBy);

        bool DeleteBirdSpecies(BirdSpecies birdSpecies);

        void UpdateBirdSpecies(BirdSpecies birdSpecies, string name);

        List<BirdSpecies> GetAllBirdSpecies();

        List<BirdSpecies> GetAllActiveBirdSpecies();

        List<BirdSpecies> GetAllDeletedBirdSpecies();

        List<Bird> GetAllBirdsByBirdSpecies(BirdSpecies birdSpecies);
    }
}
