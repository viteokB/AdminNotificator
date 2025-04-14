using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;

namespace AdminNotificator.Application.Services.Filters;

public class FilterByDepartment : IUserFilter
{
    private readonly IRepository<UserProfile> userProfileRepository;

    FilterByDepartment(IRepository<UserProfile> userProfileRepository)
    {
        this.userProfileRepository = userProfileRepository;
    }


    public Task<IEnumerable<UserProfile>> GetUserByFilter(EmailType emailType)
    {
        var targetDepartments= emailType.IntersectDepartmentIds;
        if (targetDepartments == null)
        {
            return Task.FromResult<IEnumerable<UserProfile>>(null);
        }
        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.DepartmentItems != null
                           && user.DepartmentItems.Any(department =>
                               targetDepartments.Contains(department.Id)))
            .ToList();
        return Task.FromResult(resultUsers.AsEnumerable());
    }
}