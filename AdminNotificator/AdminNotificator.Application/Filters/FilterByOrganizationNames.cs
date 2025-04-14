using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;

namespace AdminNotificator.Application.Services.Filters;

public class FilterByOrganizationNames : IUserFilter
{
    private readonly IRepository<UserProfile> userProfileRepository;

    public FilterByOrganizationNames(IRepository<UserProfile> userProfileRepository)
    {
        this.userProfileRepository = userProfileRepository;
    }

    public Task<IEnumerable<UserProfile>> GetUserByFilter(EmailType emailType)
    {
        var targetOrganizations= emailType.IntersectOrganizationNames;
        if (targetOrganizations == null)
        {
            return Task.FromResult<IEnumerable<UserProfile>>(userProfileRepository.GetAll());
        }
        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.UserPositions != null
                           && user.UserPositions.Any(position =>
                               targetOrganizations.Contains(position.OrganizationShortname)))
            .ToList();
        
        return Task.FromResult(resultUsers.AsEnumerable());
    }
}