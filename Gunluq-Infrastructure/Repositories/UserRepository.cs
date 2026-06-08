using Gunluq_Application.Interfaces;
using Gunluq_Domain.DTOs;
using Gunluq_Domain.Entities;
using Gunluq_Domain.Enums;
using Gunluq_Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gunluq_Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GunluqDbContext _gunluqDbContext;

        public UserRepository(GunluqDbContext gunluqDbContext)
        {
            _gunluqDbContext = gunluqDbContext;
        }

        public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
        {
            await _gunluqDbContext.Users.AddAsync(user, cancellationToken);
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return user;
        }

        public async Task<bool> ChangeUserRoleAsync(Guid userId, CancellationToken cancellationToken)
        {
            User? foundUser = await _gunluqDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
            if (foundUser is null) return false;
            foundUser.Role = foundUser.Role == Role.Admin ? Role.User : Role.Admin;
            foundUser.UpdatedDate = DateTime.UtcNow;
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
        {
            User? foundUser = await _gunluqDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId && x.Status == Status.Active, cancellationToken);
            if (foundUser is null)return false;
            foundUser.Status = Status.Passive;
            foundUser.DeletedDate = DateTime.UtcNow;
            foundUser.UpdatedDate = DateTime.UtcNow;
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.Users.AsNoTracking().Where(x => x.Status == Status.Active).ToListAsync(cancellationToken);
        }

        public async Task<LoginUserInfo?> GetForLoginUserAsync(string email, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.Users
                .AsNoTracking()
                .Where(x => x.Email == email &&
                    x.Status == Status.Active)
                .Select(x => new LoginUserInfo
                {
                    User = x,
                    DiaryCount = x.UserDiaries.Count(x => x.Status == Status.Active),
                    NoteCount = x.UserNotes.Count(x => x.Status == Status.Active),
                    EverydayWordCount = x.UserEverydayWords.Count(x => x.Status == Status.Active)
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User?> GetUserByEmailAsync(string email,CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email && x.Status == Status.Active,cancellationToken);
        }

        public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId && x.Status == Status.Active, cancellationToken);
        }

        public async Task<User?> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            return await _gunluqDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower() && x.Status == Status.Active, cancellationToken);
        }

        public async Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken)
        {
            User? foundUser = await _gunluqDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id && x.Status == Status.Active,
                    cancellationToken);

            foundUser!.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;
            foundUser.UserName = user.UserName;
            foundUser.Email = user.Email;
            foundUser.UpdatedDate = DateTime.UtcNow;

            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return foundUser;
        }

        public async Task<bool> UserPasswordUpdateAsync(Guid userId, string newPassword, CancellationToken cancellationToken)
        {
            User? foundUser = await _gunluqDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId && x.Status == Status.Active, cancellationToken);
            if (foundUser is null) return false;
            foundUser.Password = newPassword;
            foundUser.UpdatedDate = DateTime.UtcNow;
            await _gunluqDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
