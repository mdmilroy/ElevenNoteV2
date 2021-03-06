﻿using ElevenNote.Data;
using ElevenNote.Models;
using ElevenNoteV2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class NoteService
    {
        private readonly Guid _userId;
        private ApplicationDbContext ctx = new ApplicationDbContext();

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };

                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            var query =
                ctx
                    .Notes
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new NoteListItem
                            {
                                NoteId = e.NoteId,
                                Title = e.Title,
                                IsStarred = e.IsStarred,
                                CreatedUtc = e.CreatedUtc
                            }
                    );

            return query.ToArray();
        }

        public NoteDetail GetNoteById(int id)
        {
            var entity =
                ctx
                    .Notes
                    .Single(e => e.NoteId == id && e.OwnerId == _userId);
            return
                new NoteDetail
                {
                    NoteId = entity.NoteId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
        }

        public bool UpdateNote(NoteEdit model)
        {
            var entity =
                ctx
                    .Notes
                    .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;
            entity.IsStarred = model.IsStarred;

            return ctx.SaveChanges() == 1;
        }

        public bool DeleteNote(int noteId)
        {
            var entity =
                ctx
                    .Notes
                    .Single(n => n.NoteId == noteId);

            ctx.Notes.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }
}
