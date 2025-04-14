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