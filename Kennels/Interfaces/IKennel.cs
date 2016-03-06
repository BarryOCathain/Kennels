using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface IKennel
    {
        Kennel AddKennel(string name, User createdBy, Animal animal);

        bool DeleteKennel(Kennel kennel);

        void UpdateKennel(Kennel kennel, string name, Animal animal);

        List<Kennel> GetAllKennels();

        List<Kennel> GetAllActiveKennels();

        List<Kennel> GetAllDeletedKennels();

        List<Kennel> GetKennelsByAnimal(Animal animal);

        Kennel GetKennelByPen(Pen pen);
    }
}
