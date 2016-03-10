using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class DiscountViewModel : IDiscount
    {
        KennelsModelContainer _context;

        public DiscountViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Discount AddMultiplierDiscount(string name, double multiplier, User createdBy)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Discount Name not specified.");

            if (multiplier < 0.01)
                throw new ArgumentException("New Discount multiplier must be at least 0.01.");

            if (createdBy == null)
                throw new ArgumentException("New Discount Created By User not specified.");

            Discount d = new Discount
            {
                Name = name,
                Multiplier = multiplier,
                Value = 0.00,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now
            };

            try
            {
                _context.Discounts.Add(d);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return d;
        }

        public Discount AddValueDiscount(string name, double value, User createdBy)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Discount Name not specified.");

            if (value < 0.01)
                throw new ArgumentException("New Discount value must be at least £0.01.");

            if (createdBy == null)
                throw new ArgumentException("New Discount Created By User not specified.");

            Discount d = new Discount
            {
                Name = name,
                Multiplier = 0.00,
                Value = value,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now
            };

            try
            {
                _context.Discounts.Add(d);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return d;
        }

        public bool DeleteDiscount(Discount discount)
        {
            if (discount == null)
                throw new ArgumentException("Discount to be deleted not specified.");

            try
            {
                Discount dt = _context.Discounts.Where(d => d.Equals(discount)).FirstOrDefault();

                dt.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public List<Discount> GetAllActiveDiscounts()
        {
            return _context.Discounts.Where(d => d.IsObsolete == false).ToList();
        }

        public List<Discount> GetAllActiveMultiplierDiscounts()
        {
            return _context.Discounts.Where(d => d.IsObsolete == false && d.Multiplier > 0.00).ToList();
        }

        public List<Discount> GetAllActiveValueDiscounts()
        {
            return _context.Discounts.Where(d => d.IsObsolete == false && d.Value > 0.00).ToList();
        }

        public List<Discount> GetAllDeletedDiscounts()
        {
            return _context.Discounts.Where(d => d.IsObsolete == true).ToList();
        }

        public List<Discount> GetAllDeletedMultiplierDiscounts()
        {
            return _context.Discounts.Where(d => d.IsObsolete == true && d.Multiplier > 0.00).ToList();
        }

        public List<Discount> GetAllDeletedValueDiscounts()
        {
            return _context.Discounts.Where(d => d.IsObsolete == true && d.Value > 0.00).ToList();
        }

        public List<Discount> GetAllDiscounts()
        {
            return _context.Discounts.ToList();
        }

        public List<Discount> GetAllMultiplierDiscounts()
        {
            return _context.Discounts.Where(d => d.Multiplier > 0.00).ToList();
        }

        public List<Discount> GetAllValueDiscounts()
        {
            return _context.Discounts.Where(d => d.Value > 0.00).ToList();
        }

        public void UpdateMultiplierDiscount(Discount discount, string name, double multiplier)
        {
            if (discount == null)
                throw new ArgumentException("Discount to be updated not specified.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Discount to be updated Name not specified.");

            if (multiplier < 0.01)
                throw new ArgumentException("Discount to be updated Multiplier must be at least 0.01.");

            try
            {
                Discount dt = _context.Discounts.Where(d => d.Equals(discount)).FirstOrDefault();

                dt.Name = name;
                dt.Multiplier = multiplier;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateValueDiscount(Discount discount, string name, double value)
        {
            if (discount == null)
                throw new ArgumentException("Discount to be updated not specified.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Discount to be updated Name not specified.");

            if (value < 0.01)
                throw new ArgumentException("Discount to be updated Value must be at least £0.01.");

            try
            {
                Discount dt = _context.Discounts.Where(d => d.Equals(discount)).FirstOrDefault();

                dt.Name = name;
                dt.Value = value;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
