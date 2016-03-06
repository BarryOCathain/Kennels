using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class PaymentTypeViewModel : IPaymentType
    {
        KennelsModelContainer _context;

        public PaymentTypeViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public PaymentType AddPaymentType(string name, User createdBy)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Payment Type Name not specified.");

            if (createdBy == null)
                throw new ArgumentException("Payment Type Created By User not specified.");

            PaymentType pt = new PaymentType
            {
                Name = name,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now
            };

            try
            {
                _context.PaymentTypes.Add(pt);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return pt;
        }

        public bool DeletePaymentType(PaymentType paymentType)
        {
            try
            {
                PaymentType pt = _context.PaymentTypes.Where(p => p.Equals(paymentType)).FirstOrDefault();

                pt.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            try
            {
                return _context.PaymentTypes.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Payment> GetPaymentsByPaymentType(PaymentType paymentType)
        {
            try
            {
                return _context.Payments.Where(p => p.PaymentType.Equals(paymentType)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public PaymentType GetPAymentTypeByName(string name)
        {
            try
            {
                return _context.PaymentTypes.Where(p => p.Name.Equals(name)).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
