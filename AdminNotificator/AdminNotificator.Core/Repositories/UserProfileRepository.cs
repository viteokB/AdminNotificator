using System.Collections.Concurrent;
using System.Linq.Expressions;
using AdminNotificator.Core.Domain;

namespace AdminNotificator.Core.Repositories;

public class UserProfileRepository(AdminNotificatorDbContext context) : IRepository<UserProfile>
{
    public IQueryable<UserProfile> GetAll()
    {
        return context.UserProfiles.AsQueryable();
    }

    public async Task AddAsync(UserProfile item, CancellationToken cancellationToken = default)
    {
        await context.UserProfiles.AddAsync(item, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddAllAsync(IEnumerable<UserProfile> entities, CancellationToken cancellationToken = default)
    {
        await context.UserProfiles.AddRangeAsync(entities, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAsync(UserProfile item, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(UserProfile item, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
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