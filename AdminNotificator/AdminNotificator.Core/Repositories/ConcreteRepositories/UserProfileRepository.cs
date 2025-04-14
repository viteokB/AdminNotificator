using System.Collections.Concurrent;
using System.Linq.Expressions;
using AdminNotificator.Core.Domain;
using Microsoft.EntityFrameworkCore;

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

    public async Task DeleteAllAsync(IEnumerable<UserProfile> items, CancellationToken cancellationToken = default)
    {
        context.UserProfiles.RemoveRange(items);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(Expression<Func<UserProfile, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var itemsToDelete = await context.UserProfiles.Where(predicate).ToListAsync(cancellationToken);
        
        if (itemsToDelete.Count != 0)
        {    context.UserProfiles.RemoveRange(itemsToDelete);
            await context.SaveChangesAsync(cancellationToken);
        }
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
}