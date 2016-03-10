using System.Collections.Generic;
using System.Drawing;

namespace Kennels.Interfaces
{
    interface IHamster
    {
        Hamster AddHamster(string name, int age, User createdBy, bool isMale, Image img, Owner owner);

        bool DeleteHamster(Hamster hamster);

        void UpdateHamster(Hamster hamster, string name, int age, bool isMale, Owner owner);

        List<Hamster> GetAllHamsters();

        List<Hamster> GetAllActiveHamsters();

        List<Hamster> GetAllDeletedHamsters();

        List<Hamster> GetAllHamstersByOwner(Owner owner);

        List<Hamster> GetAllActiveHamstersByOwner(Owner owner);

        List<Hamster> GetAllDeletedHamstersByOwner(Owner owner);
    }
}
