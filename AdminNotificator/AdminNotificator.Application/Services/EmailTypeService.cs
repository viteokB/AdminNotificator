using System.Runtime.CompilerServices;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Application.Services;

public class EmailTypeService : IEmailTypeService
{
    private readonly IRepository<EmailType> emailTypeRepository;
    private readonly ILogger<EmailType> logger;

    public EmailTypeService(IRepository<EmailType> emailTypeRepository, ILogger<EmailType> logger)
    {
        this.emailTypeRepository = emailTypeRepository;
        this.logger = logger;
    }

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

    public Task<IEnumerable<EmailType>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserProfile>> GetUserProfilesByEmailType(int id)
    {

    }
}