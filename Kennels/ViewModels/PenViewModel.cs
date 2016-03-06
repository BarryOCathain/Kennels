using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class PenViewModel : IPen
    {
        KennelsModelContainer _context;

        public PenViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Pen AddPen(string name, User createdBy, int capacity, Kennel kennel)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("New Pen Name not specified.");

            if (createdBy == null)
                throw new ArgumentException("New Pen Created By User not specified.");

            if (capacity > 1)
                throw new ArgumentException("New Pen Capacity must be at least 1.");

            if (kennel == null)
                throw new ArgumentException("New Pen Kennel not specified.");

            Pen pn = new Pen
            {
                Name = name,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now,
                Capacity = capacity,
                Kennel = kennel
            };

            try
            {
                _context.Pens.Add(pn);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return pn;
        }

        public bool DeletePen(Pen pen)
        {
            if (pen == null)
                throw new ArgumentException("Pen to be deleted not specified.");

            try
            {
                Pen pn = _context.Pens.Where(p => p.Equals(pen)).FirstOrDefault();

                pn.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Pen> GetAllPens()
        {
            try
            {
                return _context.Pens.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Pen> GetPensByName(string name)
        {
            try
            {
                return _context.Pens.Where(p => p.Name.Equals(name)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Pen> GetPensInKennel(Kennel kennel)
        {
            try
            {
                return _context.Pens.Where(p => p.Kennel.Equals(kennel)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
