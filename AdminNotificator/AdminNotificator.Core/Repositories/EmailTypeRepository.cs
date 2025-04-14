using System.Linq.Expressions;
using AdminNotificator.Core.Domain;

namespace AdminNotificator.Core.Repositories;

public class EmailTypeRepository(AdminNotificatorDbContext dbContext) : IRepository<EmailType>
{
    public IQueryable<EmailType> GetAll()
    {
        return dbContext.EmailTypes;
    }

    public async Task AddAsync(EmailType item, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(item, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AddAllAsync(IEnumerable<EmailType> entities, CancellationToken cancellationToken = default)
    {
        await dbContext.AddRangeAsync(entities, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(EmailType item, CancellationToken cancellationToken = default)
    {
        dbContext.UpdateRange(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(EmailType item, CancellationToken cancellationToken = default)
    {
        dbContext.Remove(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(IEnumerable<EmailType> items, CancellationToken cancellationToken = default)
    {
        dbContext.RemoveRange(items);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(Expression<Func<EmailType, bool>> predicate, CancellationToken cancellationToken = default)
    {
        dbContext.EmailTypes.RemoveRange(dbContext.EmailTypes.Where(predicate));
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}