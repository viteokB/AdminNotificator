using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;

namespace AdminNotificator.Application.Services.Filters;

public interface IUserFilter
{
    Task<IEnumerable<UserProfile>> GetUserByFilter(EmailType emailType);
}