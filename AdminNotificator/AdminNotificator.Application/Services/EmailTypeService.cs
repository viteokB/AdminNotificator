using System.Runtime.CompilerServices;
using AdminNotificator.Application.Models.UserProfile;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Application.Services;

public class EmailTypeService : IEmailTypeService
{
    private readonly IRepository<EmailType> emailTypeRepository;
    private readonly ILogger<EmailType> logger;
    private readonly IMapper mapper;

    public EmailTypeService(
        IRepository<EmailType> emailTypeRepository,
        IRepository<UserProfile> userProfileRepository,
        ILogger<EmailType> logger,
        IMapper mapper)
    {
        this.emailTypeRepository = emailTypeRepository;
        this.logger = logger;
        this.mapper = mapper;
    }

    public Task<int> Add(EmailTypeAddDTO dto)
    {
        mapper.Map();
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