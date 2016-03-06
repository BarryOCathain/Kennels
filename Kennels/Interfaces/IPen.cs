using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IPen
    {
        Pen AddPen(string name, User createdBy, int capacity, Kennel kennel);

        bool DeletePen(Pen pen);

        List<Pen> GetAllPens();

        List<Pen> GetPensInKennel(Kennel kennel);

        List<Pen> GetPensByName(string name);
    }
}
