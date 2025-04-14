using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;

namespace AdminNotificator.Application.Services.Filters;

public class FilterByGender : IUserFilter
{
    private readonly IRepository<UserProfile> userProfileRepository;

    public FilterByGender(IRepository<UserProfile> userProfileRepository)
    {
        this.userProfileRepository = userProfileRepository;
    }

    public Task<IEnumerable<UserProfile>> GetUserByFilter(EmailType emailType)
    {
        var targetDepartments = emailType.ForGenders;
        if (targetDepartments == null)
        {
            return Task.FromResult<IEnumerable<UserProfile>>(null);
        }
        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.DepartmentItems != null
                           && targetDepartments.Equals(user.UserGender))
            .ToList();
        return Task.FromResult(resultUsers.AsEnumerable());
    }
}