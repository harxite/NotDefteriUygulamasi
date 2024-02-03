using NoteProject.DAL.Context;
using NoteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.DAL.Repositories
{
    public class NoteRepository
    {
        AppDbContext dbContext;
        public NoteRepository()
        {
            dbContext = new AppDbContext();
        }

        public void Add(Note note)
        {
            dbContext.Notes.Add(note);
            dbContext.SaveChanges();
        }

        public void Update(Note note)
        {
            dbContext.Notes.Update(note);
            dbContext.SaveChanges();
        }

        public void Delete(int noteId)
        {
            Note note = dbContext.Notes.Find(noteId);
            dbContext.Notes.Remove(note);
            dbContext.SaveChanges();
        }

        public Note GetByID(int noteId)
        {
            Note note = dbContext.Notes.Find(noteId);
            return note;
        }

        public List<Note> GetNotesByUserID(int userId)
        {
            List<Note> notes = dbContext.Notes.Where(x => x.UserID == userId && x.Status != Domain.Enums.Status.Deleted).ToList();
            return notes;
        }
    }
}
