using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class PricingViewModel : IPricing
    {
        KennelsModelContainer _context;

        public PricingViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Pricing AddPricing(double costPerNight, DateTime startDate, DateTime endDate, User createdBy, Animal animal)
        {
            if (costPerNight < 0.01)
                throw new ArgumentException("New Pricing Cost Per Night must be at least £0.01,");

            if (startDate == null)
                throw new ArgumentException("New Pricing Start Date not specified.");

            if (createdBy == null)
                throw new ArgumentException("New Pricing Created By User not specified.");

            if (animal == null)
                throw new ArgumentException("New Pricing Animal not specified.");

            Pricing pr = new Pricing
            {
                CostPerNight = costPerNight,
                StartDate = startDate,
                EndDate = endDate,
                CreatedBy = createdBy.Name,
                Animal = animal
            };

            try
            {
                _context.Pricings.Add(pr);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return pr;
        }

        public bool DeletePricing(Pricing pricing)
        {
            if (pricing == null)
                throw new ArgumentException("Pricing to be deleted not specified.");

            try
            {
                Pricing pr = _context.Pricings.Where(p => p.Equals(pricing)).FirstOrDefault();

                pr.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true; 
        }

        public List<Pricing> GetAllPricings()
        {
            try
            {
                return _context.Pricings.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Pricing GetPricingByAnimalAndDate(Animal animal, DateTime date)
        {
            if (animal == null)
                throw new ArgumentException("Pricing requested Animal not specified.");

            if (date == null)
                throw new ArgumentException("Pricing requested Date not specified.");

            try
            {
                return _context.Pricings.Where(p => p.Animal.Equals(animal) && p.StartDate <= date && (p.EndDate >= date || p.EndDate == null))
                        .FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Pricing> GetPricingsByAnimal(Animal animal)
        {
            if (animal == null)
                throw new ArgumentException("Pricings requested Animal not specified.");

            try
            {
                return _context.Pricings.Where(p => p.Animal.Equals(animal)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Pricing> GetPricingsByEndDate(DateTime endDate)
        {
            try
            {
                return _context.Pricings.Where(p => p.EndDate == endDate).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Pricing> GetPricingsByStartDate(DateTime startDate)
        {
            try
            {
                return _context.Pricings.Where(p => p.StartDate == startDate).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
