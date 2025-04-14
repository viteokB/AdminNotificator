using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Application.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IRepository<UserProfile> userProfileRepository;
    private readonly ILogger<UserProfile> logger;

    public UserProfileService(IRepository<UserProfile> userProfileRepository, ILogger<UserProfile> logger)
    {
        this.userProfileRepository = userProfileRepository;
        this.logger = logger;
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
}