using AdminNotificator.Application.Services.Filters;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Application.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IRepository<UserProfile> userProfileRepository;
    private readonly ILogger<UserProfile> logger;
    private readonly List<IUserFilter> userFilters = new List<IUserFilter>();

    public UserProfileService(IRepository<UserProfile> userProfileRepository, ILogger<UserProfile> logger, 
        FilterByDepartment filterByDepartment, FilterByGender filterByGender, 
        FilterByOrganizationNames filterByOrganizationNames, FilterByPosts filterByPosts, FilterByTowns filterByTowns)
    {
        this.userProfileRepository = userProfileRepository;
        this.logger = logger;
        userFilters.Add(filterByDepartment);
        userFilters.Add(filterByGender);
        userFilters.Add(filterByOrganizationNames);
        userFilters.Add(filterByPosts);
        userFilters.Add(filterByTowns);
        
    }

    public Task<int> Add(UserProfile userProfile)
    {
        throw new NotImplementedException();
    }

    public Task Update(UserProfile userProfile)
    {
        throw new NotImplementedException();
    }

    public Task Delete(UserProfile userProfile)
    {
        throw new NotImplementedException();
    }

    public Task<UserProfile> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserProfile>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserProfile>> GetUsersWithAllFilters(EmailType emailType)
    { 
        HashSet<UserProfile> filteredUers = new HashSet<UserProfile>();
        foreach (var filter in userFilters)
        {
            var filtered = await filter.GetUserByFilter(emailType);
            if (filtered != null)
            {
                filteredUers.IntersectWith(filtered);
            }
        }

        return filteredUers.AsEnumerable();
    }
   
}
