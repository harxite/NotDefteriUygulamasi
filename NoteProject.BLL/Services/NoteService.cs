using NoteProject.DAL.Repositories;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.BLL.Services
{
    public class NoteService
    {
        NoteRepository noteRepository;
        public NoteService()
        {
            noteRepository = new NoteRepository();
        }

        public void Add(Note note)
        {
            note.Status = Domain.Enums.Status.Added;

            noteRepository.Add(note);
        }

        public void Update(Note note)
        {
            note.Status = Domain.Enums.Status.Modified;
            note.ModifiedDate = DateTime.Now;
            noteRepository.Update(note);
        }
        public void Delete(Note note)
        {
            note.Status = Domain.Enums.Status.Deleted;
            note.DeletedDate = DateTime.Now;
            noteRepository.Update(note);
        }

        public Note GetByID(int noteId)
        {
            return noteRepository.GetByID(noteId);
        }

        public List<Note> GetAllByUserId(int userId)
        {
            return noteRepository.GetNotesByUserID(userId);
        }

    }
}
