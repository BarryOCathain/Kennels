using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class PaymentViewModel :IPayment
    {
        KennelsModelContainer _context;

        public PaymentViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Payment AddPayment(double amount, User createdBy, PaymentType paymentType, Booking booking)
        {
            if (amount > 0.01)
                throw new ArgumentException("New Payment Anount must be at least £0.01.");

            if (createdBy == null)
                throw new ArgumentException("New Payment Created By User not specified.");

            if (paymentType == null)
                throw new ArgumentException("New Payment PaymentType not specified.");

            if (booking == null)
                throw new ArgumentException("New Pamynet Booking not specified.");

            Payment p = new Payment
            {
                Amount = amount,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now,
                PaymentType = paymentType,
                Booking = booking
            };

            try
            {
                _context.Payments.Add(p);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return p;
        }

        public bool DeletePayment(Payment payment)
        {
            if (payment == null)
                throw new ArgumentException("Payment to be deleted not specified.");

            try
            {
                Payment pt = _context.Payments.Where(p => p.Equals(payment)).FirstOrDefault();

                pt.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public List<Payment> GetAllActivePayments()
        {
            return _context.Payments.Where(p => p.IsObsolete == false).ToList();
        }

        public List<Payment> GetAllDeletedPayments()
        {
            return _context.Payments.Where(p => p.IsObsolete == true).ToList();
        }

        public List<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        public List<Payment> GetPaymentsByAmountGreaterThan(double amount)
        {
            if (amount < 0.01)
                throw new ArgumentException("Payments requested minimum Amount must be at least £0.01");

            try
            {
                return _context.Payments.Where(p => p.Amount > amount).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Payment> GetPaymentsByAmountLessThan(double amount)
        {
            if (amount < 0.01)
                throw new ArgumentException("Payments requested minimum Amount must be at least £0.01");

            try
            {
                return _context.Payments.Where(p => p.Amount < amount).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Payment> GetPaymentsByBooking(Booking booking)
        {
            if (booking == null)
                throw new ArgumentException("Payments requested Booking not specified.");

            try
            {
                return _context.Payments.Where(p => p.Booking.Equals(booking)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Payment> GetPaymentsByDate(DateTime date)
        {
            if (date == null)
                throw new ArgumentException("Payments requested Date not specified.");

            try
            {
                return _context.Payments.Where(p => p.CreatedDate >= date.Date || p.CreatedDate < date.Date.AddDays(1)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Payment> GetPaymentsByPaymentType(PaymentType paymentType)
        {
            if (paymentType == null)
                throw new ArgumentException("Payments requested Payment Type not specified.");

            try
            {
                return _context.Payments.Where(p => p.PaymentType.Equals(paymentType)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Payment> GetPaymentsByPaymentTypeInDateRange(PaymentType paymentType, DateTime startDate, DateTime endDate)
        {
            if (paymentType == null)
                throw new ArgumentException("Payments requested Payment Type not specified.");

            if (startDate == null)
                throw new ArgumentException("Payments requested Start Date not specified.");

            if (endDate == null)
                throw new ArgumentException("Payments requested End Date not specified.");

            try
            {
                return _context.Payments.Where(p => p.PaymentType.Equals(paymentType) && p.CreatedDate >= startDate && p.CreatedDate <= endDate).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Payment> GetPaymentsInDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate == null)
                throw new ArgumentException("Payments requested Start Date not specified.");

            if (endDate == null)
                throw new ArgumentException("Payments requested End Date not specified.");

            try
            {
                return _context.Payments.Where(p => p.CreatedDate >= startDate && p.CreatedDate <= endDate).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
