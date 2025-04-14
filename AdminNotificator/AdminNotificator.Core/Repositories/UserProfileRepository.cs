using System.Linq.Expressions;
using AdminNotificator.Core.Domain;

namespace AdminNotificator.Core.Repositories;

public class UserProfileRepository(AdminNotificatorDbContext context) : IRepository<UserProfile>
{
    public IQueryable<UserProfile> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(UserProfile item, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task AddAllAsync(IEnumerable<UserProfile> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserProfile item, CancellationToken cancellationToken = default)
        {
            context.UserProfiles.Update(item);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(UserProfile item, CancellationToken cancellationToken = default)
        {
            context.UserProfiles.Remove(item);
            await context.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAllAsync(IEnumerable<UserProfile> items, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(Expression<Func<UserProfile, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
}