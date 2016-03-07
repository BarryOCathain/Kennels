using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class BookingViewModel : IBooking
    {
        KennelsModelContainer _context;

        public BookingViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public void AddAnimalTooBookingPen(Booking booking, Pen pen, Animal animal)
        {
            if (booking == null)
                throw new ArgumentException("Booking that Animal is to be added to not specified.");

            if (pen == null)
                throw new ArgumentException("Booking Pen that Animal is to be added to not specified.");

            if (animal == null)
                throw new ArgumentException("Animal to be added to Booking Pen not specified.");

            try
            {
                Booking bk = _context.Bookings.Where(b => b.Equals(booking)).FirstOrDefault();

                if (bk != null)
                {
                    foreach (Pen _pen in bk.Pens)
                    {
                        if (_pen.Animals.Contains(animal))
                            throw new InvalidOperationException("Animal to be added to Booking already exists.");
                    }

                    Pen pn = bk.Pens.Where(p => p.Equals(pen)).FirstOrDefault();

                    if (pn != null)
                    {
                        pn.Animals.Add(animal);

                        _context.SaveChanges();
                    }
                    else
                        throw new InvalidOperationException("Booking Pen that Animal is to be added to not found.");
                }
                else
                    throw new InvalidOperationException("Booking that Animal is to be added to not found.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Booking AddBooking(DateTime startDate, DateTime endDate, double cost, User createdBy, Owner owner)
        {
            Booking b = new Booking
            {
                StartDate = startDate,
                EndDate = endDate,
                Cost = 0.00,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now,
                Owner = owner,
                Payments = new List<Payment>(),
                Discounts = new List<Discount>(),
                Pens = new List<Pen>()
            };

            try
            {
                _context.Bookings.Add(b);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return b;
        }

        public void AddPenToBooking(Booking booking, Pen pen)
        {
            if (booking == null)
                throw new ArgumentException("Booking that Pen is to be added to not specified.");

            if (pen == null)
                throw new ArgumentException("Pen to be added to Booking not specified.");

            if (booking.Pens.Contains(pen))
                throw new InvalidOperationException("Pen to be added to Booking already exists.");

            Booking bk = _context.Bookings.Where(b => b.Equals(booking)).FirstOrDefault();

            try
            {
                if (bk != null)
                {
                    bk.Pens.Add(pen);

                    _context.SaveChanges();
                }
                else
                    throw new InvalidOperationException("Booking that Pen is to be added to not found.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CalculateCost(Booking booking)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBooking(Booking booking)
        {
            if (booking == null)
                throw new ArgumentException("Booking to be deleted not specified.");

            Booking bk = _context.Bookings.Where(b => b.Equals(booking))
        }

        public List<Booking> GetAllActiveBookings()
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAllBookings()
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAllDeletedBOokings()
        {
            throw new NotImplementedException();
        }

        public void RemoveAnimalFromBookingPen(Booking booking, Pen pen, Animal animal)
        {
            throw new NotImplementedException();
        }

        public void RemovePenFromBooking(Booking booking, Pen pen)
        {
            throw new NotImplementedException();
        }
    }
}
