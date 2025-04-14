using AdminNotificator.Core.Domain;

namespace AdminNotificator.Application.Services;

public interface IUserProfileService
{
    public Task<int> Add(UserProfile userProfile);
    public Task Update(UserProfile userProfile);
    public Task Delete(UserProfile userProfile);
    public Task<UserProfile> Get(int id);
    public Task<IEnumerable<UserProfile>> GetAll();
}