using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kennels.Interfaces
{
    interface INote
    {
        Note AddNote(string content, User createdBy, Animal animal);

        bool DeleteNote(Note note);

        void UpdateNote(Note note, string content);

        List<Note> GetAllNotes();

        List<Note> GetAllActiveNotes();

        List<Note> GetAllDeletedNotes();

        List<Note> GetAllNotesByAnimal(Animal animal);
    }
}
