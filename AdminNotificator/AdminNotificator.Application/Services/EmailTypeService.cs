using AdminNotificator.Application.Models.UserProfile;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Application.Services;

public class EmailTypeService : IEmailTypeService
{
    private readonly IRepository<EmailType> emailTypeRepository;
    private readonly IRepository<UserProfile> userProfileRepository;
    private readonly ILogger<EmailTypeService> logger;
    private readonly IMapper mapper;

    public EmailTypeService(
        IRepository<EmailType> emailTypeRepository,
        IRepository<UserProfile> userProfileRepository,
        ILogger<EmailTypeService> logger,
        IMapper mapper)
    {
        this.emailTypeRepository = emailTypeRepository;
        this.userProfileRepository = userProfileRepository;
        this.logger = logger;
        this.mapper = mapper;
    }

    public async Task<string> Add(EmailTypeAddDTO dto)
    {
        var entity = mapper.Map<EmailTypeAddDTO, EmailType>(dto);
        await emailTypeRepository.AddAsync(entity);
        logger.Log(LogLevel.Information, "email type added");
        return entity.Id;
    }

    public async Task Update(EmailTypeUpdateDTO dto)
    {
        var entity = mapper.Map<EmailTypeUpdateDTO, EmailType>(dto);
        await emailTypeRepository.UpdateAsync(entity);
        logger.Log(LogLevel.Information, "email type updated");
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
}