using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Application.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IRepository<UserProfile> userProfileRepository;
    private readonly ILogger<UserProfile> logger;
    private readonly UsersFilter usersFilter;

    public UserProfileService(IRepository<UserProfile> userProfileRepository, ILogger<UserProfile> logger,
        UsersFilter usersFilter)
    {
        this.userProfileRepository = userProfileRepository;
        this.logger = logger;
        this.usersFilter = usersFilter;
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
        if (emailType == null)
        {
            return Enumerable.Empty<UserProfile>();
        }

        // Собираем все задачи фильтрации
        var filterTasks = new List<Task<IEnumerable<UserProfile>>>();
    
        // Добавляем только те фильтры, которые имеют значения
        if (emailType.IntersectTowns?.Any() == true)
            filterTasks.Add(usersFilter.GetUsersByIntersectTown(emailType));
    
        if (emailType.IntersectOrganizationNames?.Any() == true)
            filterTasks.Add(usersFilter.GetUsersByIntersectOrganizationNames(emailType));
    
        if (emailType.IntersectDepartmentIds?.Any() == true)
            filterTasks.Add(usersFilter.GetUsersByIntersectDepartment(emailType));
    
        if (emailType.ForGenders != null)
            filterTasks.Add(usersFilter.GetUsersByIntersectGenders(emailType));
        
        var filteredResults = await Task.WhenAll(filterTasks);
    
        var commonUsers = filteredResults
            .Aggregate((current, next) => current.Intersect(next))
            .ToList();

        return commonUsers;
    }
   
}