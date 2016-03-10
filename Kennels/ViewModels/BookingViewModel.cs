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

            if (!booking.Pens.Contains(pen))
                throw new InvalidOperationException("Booking Pen that Animal is to be added to not found.");

            try
            {
                Booking bkg = _context.Bookings.Where(b => b.Equals(booking)).FirstOrDefault();

                if (bkg != null)
                {
                    foreach (Pen _pen in bkg.Pens)
                    {
                        if (_pen.Animals.Contains(animal))
                            throw new InvalidOperationException("Booking already contains that Animal.");

                        if (_pen.Equals(pen))
                        {
                            _pen.Animals.Add(animal);
                            _context.SaveChanges();
                            break;
                        }
                    }
                }
                else
                    throw new InvalidOperationException("Booking specified could not be found.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Booking AddBooking(DateTime startDate, DateTime endDate, User createdBy, Owner owner)
        {
            if (startDate == null)
                throw new ArgumentException("New Booking Start Date not specified.");

            if (endDate == null)
                throw new ArgumentException("New Booking End Date not specified.");

            if (createdBy == null)
                throw new ArgumentException("New Booking Created By User not specified.");

            if (owner == null)
                throw new ArgumentException("New Booking Owner not specified.");

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
                throw;
            }
            return b;
        }

        public void AddPenToBooking(Booking booking, Pen pen)
        {
            if (booking == null)
                throw new ArgumentException("Booking that Pen is to be added to not specified.");

            if (pen == null)
                throw new ArgumentException("Pen to be added to Booking not specified.");

            Booking bkg = _context.Bookings.Where(b => b.Equals(booking)).FirstOrDefault();

            if (bkg != null)
            {
                if (bkg.Pens.Contains(pen))
                    throw new InvalidOperationException("Pen to be added to Booking already exists.");

                if (GetAvailablePens(booking.StartDate, booking.EndDate).Contains(pen))
                    booking.Pens.Add(pen);
                else
                    throw new InvalidOperationException("Pen to be added to Booking is not available.");

                _context.SaveChanges();
            }
            else
                throw new InvalidOperationException("Booking that Pen is to be added to not found.");
        }

        public void CalculateCost(Booking booking)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBooking(Booking booking)
        {
            if (booking == null)
                throw new ArgumentException("Booking to be deleted not specified.");

            try
            {
                Booking bkg = _context.Bookings.Where(b => b.Equals(booking)).FirstOrDefault();

                if (bkg != null)
                {
                    bkg.IsObsolete = true;

                    _context.SaveChanges();

                    return true;
                }
                else
                    throw new InvalidOperationException("Booking to be deleted not found.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Booking> GetAllActiveBookings()
        {
            return _context.Bookings.Where(b => b.IsObsolete == false).ToList();
        }

        public List<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public List<Booking> GetAllDeletedBookings()
        {
            return _context.Bookings.Where(b => b.IsObsolete == true).ToList();
        }

        public List<Pen> GetAvailablePens(DateTime startDate, DateTime endDate)
        {
            if (startDate == null)
                throw new ArgumentException("Pens requested Start Date not specified.");

            if (endDate == null)
                throw new ArgumentException("Pens requested End Date not specified.");

            try
            {
                List<Pen> availablePens = _context.Pens.ToList();

                foreach (Booking bkg in _context.Bookings.Where(b => (b.EndDate >= startDate && b.EndDate <= endDate)
                    || (b.StartDate >= startDate && b.StartDate <= endDate)).ToList())
                {
                    foreach (Pen pn in bkg.Pens)
                    {
                        if (availablePens.Contains(pn)) availablePens.Remove(pn);
                    }
                }

                return availablePens;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveAnimalFromBooking(Booking booking, Animal animal)
        {
            bool exists = false;

            if (booking == null)
                throw new ArgumentException("Booking the Animal is to be removed from not specified.");

            if (animal == null)
                throw new ArgumentException("Animal to be removed from Booking Pen not specified.");

            try
            {
                Booking bkg = _context.Bookings.Where(b => b.Equals(booking)).FirstOrDefault();

                if (bkg != null)
                {
                    foreach (Pen pn in bkg.Pens)
                    {
                        if (pn.Animals.Contains(animal))
                        {
                            pn.Animals.Remove(animal);
                            exists = true;
                        }
                    }

                    if (!exists)
                        throw new InvalidOperationException("Animal to be removed from Booking not found.");

                    _context.SaveChanges();
                }
                else
                    throw new InvalidOperationException("Booking that Animal is to be removed from not found.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemovePenFromBooking(Booking booking, Pen pen)
        {
            if (booking == null)
                throw new ArgumentException("Booking that Pen is to be removed from not specified.");

            if (pen == null)
                throw new ArgumentException("Booking that Pen is to be removed from not speicifed.");

            Booking bkg = _context.Bookings.Where(b => b.Equals(booking)).FirstOrDefault();

            if (bkg != null)
            {
                if (bkg.Pens.Contains(pen))
                    bkg.Pens.Remove(pen);
                else
                    throw new InvalidOperationException("Pen to be removed from booking not found.");
            }
            else
                throw new InvalidOperationException("Booking that Pen is to be removed from not found.");
        }
    }
}
