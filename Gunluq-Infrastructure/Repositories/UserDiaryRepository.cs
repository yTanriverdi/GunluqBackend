using Gunluq_Application.Interfaces;
using Gunluq_Domain.Entities;
using Gunluq_Domain.Enums;
using Gunluq_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gunluq_Infrastructure.Repositories
{
    public class UserDiaryRepository : IUserDiaryRepository
    {
        private readonly GunluqDbContext _gunluqDbContext;

        public UserDiaryRepository(GunluqDbContext gunluqDbContext)
        {
            _gunluqDbContext = gunluqDbContext;
        }
        public async Task<UserDiary> AddUserDiaryAsync(UserDiary userDiary, CancellationToken cancellationToken)
        {
            await _gunluqDbContext.UserDiaries.AddAsync(userDiary, cancellationToken);
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return userDiary;
        }

        public async Task<bool> DeleteAsync(Guid userDiaryId, CancellationToken cancellationToken)
        {
            UserDiary? userDiary = await _gunluqDbContext.UserDiaries.FirstOrDefaultAsync(x => x.Id == userDiaryId, cancellationToken);
            if (userDiary is null) return false;
            userDiary.UpdatedDate = DateTime.UtcNow;
            userDiary.DeletedDate = DateTime.UtcNow;
            userDiary.Status = Status.Passive;
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<UserDiary>> GetAllActiveAsync(CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserDiaries.Where(x => x.Status == Status.Active).ToListAsync(cancellationToken);
        }

        public async Task<List<UserDiary>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserDiaries.ToListAsync(cancellationToken);
        }

        public async Task<List<UserDiary>> GetAllUserDiaryByDiaryTagAsync(DiaryTag diaryTag, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserDiaries.Where(x => x.DiaryTag == diaryTag).ToListAsync(cancellationToken);
        }

        public async Task<List<UserDiary>> GetAllUserDiaryByFeelAsync(Feel feel, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserDiaries.Where(x => x.Feel == feel).ToListAsync(cancellationToken);
        }

        public async Task<List<UserDiary>> GetAllUserDiaryByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserDiaries.Where(x => x.UserId == userId && x.Status == Status.Active).OrderByDescending(x => x.CreatedDate).ToListAsync(cancellationToken);
        }

        public async Task<UserDiary?> GetUserDiaryByIdAsync(Guid userDiaryId, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.UserDiaries.Where(x => x.Id == userDiaryId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<UserDiary?> GetUserDiaryInDayAsync(Guid userId, CancellationToken cancellationToken)
        {
            DateTime startOfDay = DateTime.UtcNow.Date;
            DateTime endOfDay = startOfDay.AddDays(1);

            return await _gunluqDbContext.UserDiaries.FirstOrDefaultAsync(x => x.UserId == userId && (x.CreatedDate >= startOfDay && x.CreatedDate < endOfDay) && x.Status == Status.Active, cancellationToken);
        }

        public async Task<UserDiary> UpdateUserDiaryAsync(UserDiary userDiary, CancellationToken cancellationToken)
        {
            UserDiary foundUserDiary = await _gunluqDbContext.UserDiaries.Where(x => x.Id == userDiary.Id && x.Status == Status.Active).FirstAsync(cancellationToken);
            foundUserDiary.UpdatedDate = DateTime.UtcNow;
            foundUserDiary.Content = userDiary.Content;
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return foundUserDiary;
        }
    }
}
