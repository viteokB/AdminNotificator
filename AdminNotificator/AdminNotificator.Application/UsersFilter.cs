using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;

namespace AdminNotificator.Application.Services;

public class UsersFilter
{
    private readonly IRepository<UserProfile> userProfileRepository;

    UsersFilter(UserProfileRepository userProfileRepository)
    {
        this.userProfileRepository = userProfileRepository;
    }

    public Task<IEnumerable<UserProfile>> GetUsersByIntersectTown(EmailType emailType)
    {
        var targetTowns = emailType.IntersectTowns;

        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.UserOffice.Town != null
                           && targetTowns.Contains(user.UserOffice.Town)).ToList();
        
        return Task.FromResult(resultUsers.AsEnumerable());
    }

    public Task<IEnumerable<UserProfile>> GetUsersByIntersectOrganizationNames(EmailType emailType)
    {
        var targetOrganizations= emailType.IntersectOrganizationNames;
        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.UserPositions != null
                           && user.UserPositions.Any(position =>
                               targetOrganizations.Contains(position.OrganizationShortname)))
            .ToList();
        
        return Task.FromResult(resultUsers.AsEnumerable());
    }

    public Task<IEnumerable<UserProfile>> GetUsersByIntersectDepartment(EmailType emailType)
    {
        var targetDepartments= emailType.IntersectDepartmentIds;
        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.DepartmentItems != null
                           && user.DepartmentItems.Any(department =>
                               targetDepartments.Contains(department.Id)))
            .ToList();
        return Task.FromResult(resultUsers.AsEnumerable());
    }
    public Task<IEnumerable<UserProfile>> GetUsersByIntersectGenders(EmailType emailType)
    {
        var targetDepartments = emailType.ForGenders;
        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.DepartmentItems != null
                           && targetDepartments.Equals(user.UserGender))
            .ToList();
        return Task.FromResult(resultUsers.AsEnumerable());
    }
    public Task<IEnumerable<UserProfile>> GetUsersByIntersectUserPosts(EmailType emailType)
    {
        var targetPosts = emailType.IntersectUserPosts;
        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.UserPositions != null
                           && user.UserPositions.Any(post =>
                               targetPosts.Contains(post.Post)))
            .ToList();
        return Task.FromResult(resultUsers.AsEnumerable());
    }
}