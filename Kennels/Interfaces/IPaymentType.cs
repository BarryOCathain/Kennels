using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IPaymentType
    {
        PaymentType AddPaymentType(string name, User createdBy);

        bool DeletePaymentType(PaymentType paymentType);

        List<PaymentType> GetAllPaymentTypes();

        PaymentType GetPaymentTypeByName(string name);

        List<Payment> GetPaymentsByPaymentType(PaymentType paymentType);
    }
}
