using AdminNotificator.Application.Models.EmailType;
using AdminNotificator.Core.Domain;

namespace AdminNotificator.Application.Services;

public interface IEmailTypeService
{
    public Task<int> Add(EmailType emailType)
    {
        throw new NotImplementedException();
    }

    public Task Update(EmailType emailType)
    {
        throw new NotImplementedException();
    }

    public Task Delete(EmailType emailType)
    {
        throw new NotImplementedException();
    }

    public Task<UserProfile> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserProfile>> GetEmailsType(EmailTypeSearchDTO emailType);

    public Task<IEnumerable<UserProfile>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserProfile>> GetUserProfilesByEmailType(int id);
}