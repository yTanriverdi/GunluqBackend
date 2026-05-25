using Gunluq_Application.Interfaces;
using Gunluq_Domain.Entities;
using Gunluq_Domain.Enums;
using Gunluq_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gunluq_Infrastructure.Repositories
{
    public class UserEverydayWordRepository : IUserEverydayWordRepository
    {
        private readonly GunluqDbContext _gunluqDbContext;

        public UserEverydayWordRepository(GunluqDbContext gunluqDbContext)
        {
            _gunluqDbContext = gunluqDbContext;
        }

        public async Task<UserEverydayWord> AddUserEverydayWordAsync(UserEverydayWord userEverydayWord, CancellationToken cancellationToken)
        {
            await _gunluqDbContext.UserEverydayWords.AddAsync(userEverydayWord, cancellationToken);
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return userEverydayWord;
        }

        public async Task<bool> DeleteEverydayWordAsync(Guid userEverydayWordId, CancellationToken cancellationToken)
        {
            UserEverydayWord? foundUserEverydayWord = await _gunluqDbContext.UserEverydayWords.FirstOrDefaultAsync(x => x.Id == userEverydayWordId, cancellationToken);
            if (foundUserEverydayWord is null) return false;
            foundUserEverydayWord.DeletedDate = DateTime.UtcNow;
            foundUserEverydayWord.UpdatedDate = DateTime.UtcNow;
            foundUserEverydayWord.Status = Status.Passive;
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<UserEverydayWord>> GetAllEverydayWordByInDayAsync(CancellationToken cancellationToken)
        {
            DateTime startDate = DateTime.UtcNow.Date;
            DateTime endDate = startDate.AddDays(1);
            return await _gunluqDbContext.UserEverydayWords.Where(x => x.Status == Status.Active && x.CreatedDate >= startDate && x.CreatedDate < endDate).ToListAsync(cancellationToken);
        }

        public async Task<List<UserEverydayWord>> GetAllUserEverydayWordAsync(CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserEverydayWords.ToListAsync(cancellationToken);
        }

        public async Task<List<UserEverydayWord>> GetAllUserEverydayWordByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserEverydayWords.Where(x => x.UserId == userId).ToListAsync(cancellationToken);
        }

        public async Task<UserEverydayWord?> GetUserEverydayWordByIdAsync(Guid Id, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserEverydayWords.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        }

        public async Task<UserEverydayWord?> GetUserEverydayWordByInDayUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            DateTime startDate = DateTime.UtcNow.Date;
            DateTime endDate = startDate.AddDays(1);
            return await _gunluqDbContext.UserEverydayWords.FirstOrDefaultAsync(x => x.Status == Status.Active && x.CreatedDate >= startDate && x.CreatedDate < endDate, cancellationToken);
        }

        public async Task<UserEverydayWord> UpdateEverydayWordAsync(UserEverydayWord userEverydayWord, CancellationToken cancellationToken)
        {
            UserEverydayWord foundUserEveryDayWord = await _gunluqDbContext.UserEverydayWords.FirstAsync(x => x.Id == userEverydayWord.Id, cancellationToken);
            foundUserEveryDayWord.UpdatedDate = DateTime.UtcNow;
            foundUserEveryDayWord.Content = userEverydayWord.Content;
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return foundUserEveryDayWord;
        }
    }
}
