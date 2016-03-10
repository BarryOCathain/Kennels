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
                throw;
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
                throw;
            }
            return true;
        }

        public List<Note> GetAllActiveNotes()
        {
            return _context.Notes.Where(n => n.IsObsolete == false).ToList();
        }

        public List<Note> GetAllDeletedNotes()
        {
            return _context.Notes.Where(n => n.IsObsolete == true).ToList();
        }

        public List<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        public List<Note> GetAllNotesByAnimal(Animal animal)
        {
            if (animal == null)
                throw new ArgumentException("Animal that Notes are to be retrieved for not specified.");

            try
            {
                return _context.Notes.Where(n => n.Animal.Equals(animal)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateNote(Note note, string content)
        {
            if (note == null)
                throw new ArgumentException("Note to be updated not specified.");

            if (string.IsNullOrEmpty(content))
                throw new ArgumentException("Note to be updated Content not specified.");

            try
            {
                Note nt = _context.Notes.Where(n => n.Equals(note)).FirstOrDefault();

                nt.Content = content;

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
