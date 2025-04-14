using System.Collections.Concurrent;
using System.Linq.Expressions;
using AdminNotificator.Core.Domain;

namespace AdminNotificator.Core.Repositories;

public class UserProfileRepository : IRepository<UserProfile>
{

    private readonly AdminNotificatorDbContext _dBcontext;

    UserProfileRepository(AdminNotificatorDbContext context)
    {
        _dBcontext = context;
    }
    
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

    public Task UpdateAsync(UserProfile item, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(UserProfile item, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAllAsync(IEnumerable<UserProfile> items, CancellationToken cancellationToken = default)
    {
        _dBcontext.UserProfiles.RemoveRange(items);
        await _dBcontext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(Expression<Func<UserProfile, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}