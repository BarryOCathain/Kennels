using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IDiscount
    {
        Discount AddMultiplierDiscount(string name, double multiplier, User createdBy);

        Discount AddValueDiscount(string name, double value, User createdBy);

        bool DeleteDiscount(Discount discount);

        void UpdateMultiplierDiscount(Discount discount, string name, double multiplier);

        void UpdateValueDiscount(Discount discount, string name, double value);

        List<Discount> GetAllDiscounts();

        List<Discount> GetAllMultiplierDiscounts();

        List<Discount> GetAllValueDiscounts();

        List<Discount> GetAllActiveDiscounts();

        List<Discount> GetAllDeletedDiscounts();

        List<Discount> GetAllActiveMultiplierDiscounts();

        List<Discount> GetAllDeletedMultiplierDiscounts();

        List<Discount> GetAllActiveValueDiscounts();

        List<Discount> GetAllDeletedValueDiscounts();
    }
}
