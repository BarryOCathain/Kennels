using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IPricing
    {
        Pricing AddPricing(double costPerNight, DateTime startDate, DateTime endDate, User createdBy, Animal animal);

        bool DeletePricing(Pricing pricing);

        List<Pricing> GetAllPricings();

        List<Pricing> GetPricingsByStartDate(DateTime startDate);

        List<Pricing> GetPricingsByEndDate(DateTime endDate);

        Pricing GetPricingByAnimalAndDate(Animal animal, DateTime date);

        List<Pricing> GetPricingsByAnimal(Animal animal);
    }
}
