using AdminNotificator.Core.Domain;

namespace AdminNotificator.Core.Repositories;

public interface IEmailTypeRepository : IRepository<EmailType>
{
    public IEnumerable<UserProfile> FilterByEmailType(IQueryable<UserProfile> query, EmailType searchDto);
}