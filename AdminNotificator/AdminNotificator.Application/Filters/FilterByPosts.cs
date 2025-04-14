using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;

namespace AdminNotificator.Application.Services.Filters;

public class FilterByPosts : IUserFilter
{
    private readonly IRepository<UserProfile> userProfileRepository;

    public FilterByPosts(IRepository<UserProfile> userProfileRepository)
    {
        this.userProfileRepository = userProfileRepository;
    }

    public Task<IEnumerable<UserProfile>> GetUserByFilter(EmailType emailType)
    {
        var targetPosts = emailType.IntersectUserPosts;
        if (targetPosts == null)
        {
            return Task.FromResult<IEnumerable<UserProfile>>(null);
        }
        var resultUsers = userProfileRepository.GetAll()
            .Where(user => user.UserPositions != null
                           && user.UserPositions.Any(post =>
                               targetPosts.Contains(post.Post)))
            .ToList();
        return Task.FromResult(resultUsers.AsEnumerable());
    }
}