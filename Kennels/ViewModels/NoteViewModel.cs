using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kennels.Interfaces;

namespace Kennels.ViewModels
{
    class NoteViewModel : INote
    {
        KennelsModelContainer _context;

        public NoteViewModel(KennelsModelContainer context)
        {
            _context = context;
        }

        public Note AddNote(string content, User createdBy, Animal animal)
        {
            Note n = new Note
            {
                Content = content,
                IsObsolete = false,
                CreatedBy = createdBy.Name,
                CreatedDate = DateTime.Now,
                Animal = animal
            };

            try
            {
                _context.Notes.Add(n);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return n;
        }

        public bool DeleteNote(Note note)
        {
            try
            {
                Note nt = _context.Notes.Where(n => n.Equals(note)).FirstOrDefault();

                nt.IsObsolete = true;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<Note> GetAllActiveNotes()
        {
            try
            {
                return _context.Notes.Where(n => n.IsObsolete == false).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Note> GetAllDeletedNotes()
        {
            try
            {
                return _context.Notes.Where(n => n.IsObsolete == true).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Note> GetAllNotes()
        {
            try
            {
                return _context.Notes.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Note> GetAllNotesByAnimal(Animal animal)
        {
            try
            {
                return _context.Notes.Where(n => n.Animal.Equals(animal)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateNote(Note note, string content)
        {
            try
            {
                Note nt = _context.Notes.Where(n => n.Equals(note)).FirstOrDefault();

                nt.Content = content;

                _context.SaveChanges();
            }
            catch (Exception) { }
        }
    }
}
