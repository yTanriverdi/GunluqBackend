using Gunluq_Application.Interfaces;
using Gunluq_Domain.Entities;
using Gunluq_Domain.Enums;
using Gunluq_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gunluq_Infrastructure.Repositories
{
    public class UserNoteRepository : IUserNoteRepository
    {
        private readonly GunluqDbContext _gunluqDbContext;

        public UserNoteRepository(GunluqDbContext gunluqDbContext)
        {
            _gunluqDbContext = gunluqDbContext;
        }

        public async Task<UserNote> AddUserNoteAsync(UserNote userNote, CancellationToken cancellationToken)
        {
            await _gunluqDbContext.AddAsync(userNote, cancellationToken);
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return userNote;
        }

        public async Task<bool> DeleteUserNoteByIdAsync(Guid userNoteId, CancellationToken cancellationToken)
        {
            UserNote? userNote = await _gunluqDbContext.UserNotes.FirstOrDefaultAsync(x => x.Id == userNoteId, cancellationToken);
            if (userNote is null) return false;
            userNote.Status = Status.Passive;
            userNote.DeletedDate = DateTime.UtcNow;
            userNote.UpdatedDate = DateTime.UtcNow;
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<UserNote>> GetAllUserNoteAsnc(CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserNotes.ToListAsync(cancellationToken);
        }

        public async Task<List<UserNote>> GetAllUserNoteByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserNotes.Where(x => x.UserId == userId && x.Status == Status.Active).OrderByDescending(x => x.CreatedDate).ToListAsync(cancellationToken);
        }

        public async Task<UserNote?> GetUserNoteByIdAsync(Guid userNoteId, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserNotes.FirstOrDefaultAsync(x => x.Id == userNoteId, cancellationToken);
        }

        public async Task<UserNote> UpdateUserNoteAsync(UserNote userNote, CancellationToken cancellationToken)
        {
            UserNote foundUserNote = await _gunluqDbContext.UserNotes.FirstAsync(x => x.Id == userNote.Id, cancellationToken);
            foundUserNote.UpdatedDate = DateTime.UtcNow;
            foundUserNote.Content = userNote.Content;
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return foundUserNote;
        }
    }
}
