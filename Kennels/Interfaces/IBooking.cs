using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IBooking
    {
        Booking AddBooking(DateTime startDate, DateTime endDate, User createdBy, Owner owner);

        bool DeleteBooking(Booking booking);

        void AddPenToBooking(Booking booking, Pen pen);

        void AddAnimalTooBookingPen(Booking booking, Pen pen, Animal animal);

        void CalculateCost(Booking booking);

        void RemoveAnimalFromBooking(Booking booking, Animal animal);

        void RemovePenFromBooking(Booking booking, Pen pen);

        List<Booking> GetAllBookings();

        List<Booking> GetAllActiveBookings();

        List<Booking> GetAllDeletedBookings();

        List<Pen> GetAvailablePens(DateTime startDate, DateTime endDate);
    }
}
