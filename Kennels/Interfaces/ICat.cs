using System.Collections.Generic;
using System.Drawing;

namespace Kennels.Interfaces
{
    interface ICat
    {
        Cat AddCat(string name, int age, User createdBy, bool isMale, Image img, Owner owner);

        bool DeleteCat(Cat cat);

        void UpdateCat(Cat cat, string name, int age, bool isMale, Owner owner);

        List<Cat> GetAllCats();

        List<Cat> GetAllActiveCats();

        List<Cat> GetAllDeletedCats();
    }
}
