using System.Linq.Expressions;
using AdminNotificator.Core.Domain;

namespace AdminNotificator.Core.Repositories;

public class EmailTypeRepository : IRepository<EmailType>
{
    public IQueryable<EmailType> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(EmailType item, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddAllAsync(IEnumerable<EmailType> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(EmailType item, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(EmailType item, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAllAsync(IEnumerable<EmailType> items, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAllAsync(Expression<Func<EmailType, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}