using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;

namespace AdminNotificator.Application.Services.Filters;

public class FilterByTowns : IUserFilter
{
    private readonly IRepository<UserProfile> userProfileRepository;

    public FilterByTowns(IRepository<UserProfile> userProfileRepository)
    {
        this.userProfileRepository = userProfileRepository;
    }

    public Task<IEnumerable<UserProfile>> GetUserByFilter(EmailType emailType)
    {
        var targetTowns = emailType.IntersectTowns;
        if (targetTowns == null)
        {
            return Task.FromResult<IEnumerable<UserProfile>>(null);
        }
        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.UserOffice.Town != null
                           && targetTowns.Contains(user.UserOffice.Town)).ToList();
        
        return Task.FromResult(resultUsers.AsEnumerable());
    }
}