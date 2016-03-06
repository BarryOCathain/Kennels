using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IPayment
    {
        Payment AddPayment(double amount, User createdBy, PaymentType paymentType, Booking booking);

        bool DeletePayment(Payment payment);

        List<Payment> GetAllPayments();

        List<Payment> GetAllActivePayments();

        List<Payment> GetAllDeletedPayments();

        List<Payment> GetPaymentsByPaymentType(PaymentType paymentType);

        List<Payment> GetPaymentsByBooking(Booking booking);

        List<Payment> GetPaymentsByDate(DateTime date);

        List<Payment> GetPaymentsInDateRange(DateTime startDate, DateTime endDate);

        List<Payment> GetPaymentsByAmountGreaterThan(double amount);

        List<Payment> GetPaymentsByAmountLessThan(double amount);

        List<Payment> GetPaymentsByPaymentTypeInDateRange(PaymentType paymentType, DateTime startDate, DateTime endDate);
    }
}
