using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class KennelViewModel : IKennel
    {
        KennelsModelContainer _context;

        public KennelViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Kennel AddKennel(string name, User createdBy, Animal animal)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Kennel Name not specified.");

            if (createdBy == null)
                throw new ArgumentException("New Kennel Created By User not specified.");

            if (animal == null)
                throw new ArgumentException("New Kennel Animal not specified.");

            Kennel k = new Kennel
            {
                Name = name,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now,
                Animal = animal
            };

            try
            {
                _context.Kennels.Add(k);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return k;
        }

        public bool DeleteKennel(Kennel kennel)
        {
            if (kennel == null)
                throw new ArgumentException("Kennel to be deleted not specified.");

            try
            {
                Kennel knl = _context.Kennels.Where(k => k.Equals(kennel)).FirstOrDefault();

                knl.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Kennel> GetAllActiveKennels()
        {
            try
            {
                return _context.Kennels.Where(k => k.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Kennel> GetAllDeletedKennels()
        {
            try
            {
                return _context.Kennels.Where(k => k.IsObsolete == true).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Kennel> GetAllKennels()
        {
            try
            {
                return _context.Kennels.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Kennel GetKennelByPen(Pen pen)
        {
            if (pen == null)
                throw new ArgumentException("Kennel requested Pen not specififed.");

            try
            {
                return _context.Kennels.Where(k => k.Pens.Contains(pen)).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Kennel> GetKennelsByAnimal(Animal animal)
        {

            if (animal == null)
                throw new ArgumentException("Kennels requested Animal not specified.");
            try
            {
                return _context.Kennels.Where(k => k.Animal.Equals(animal)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateKennel(Kennel kennel, string name, Animal animal)
        {
            if (kennel == null)
                throw new ArgumentException("Kennel to be updated not specified.");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Kennel to be updated Name not specified.");

            if (animal == null)
                throw new ArgumentException("Kennel to be updated Animal not specified.");

            try
            {
                Kennel knl = _context.Kennels.Where(k => k.Equals(kennel)).FirstOrDefault();

                knl.Name = name;
                knl.Animal = animal;

                _context.SaveChanges();
            }
            catch (Exception) { }
        }
    }
}
