using AdminNotificator.Core.Domain;

namespace AdminNotificator.Application.Services;

public interface IEmailTypeService
{
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

    public Task<IEnumerable<UserProfile>> GetUserProfilesByEmailType(int id);
}