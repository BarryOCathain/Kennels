using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IOwner
    {
        Owner AddOwner(string firstName, string surname, string propNameNum, string add1, string add2, string add3,
            string postcode, string phone1, string phone2, string email, User createdBy);

        bool DeleteOwner(Owner owner);

        void UpdateOwner(Owner owner, string firstName, string surname, string propNameNum, string add1, string add2, string add3,
            string postcode, string phone1, string phone2, string email);

        List<Owner> GetOwnersByFirstName(string firstName);

        List<Owner> GetOwnersBySurname(string surname);

        List<Owner> GetOwnersByFirstNameAndSurname(string firstName, string surname);

        List<Owner> GetAllOwners();

        List<Booking> GetOwnerBookings(Owner owner);

        List<Animal> GetOwnerAnimals(Owner owner);
    }
}
