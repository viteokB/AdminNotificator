using System.Runtime.CompilerServices;
using AdminNotificator.Application.Models.EmailType;
using AdminNotificator.Application.Models.UserProfile;
using AdminNotificator.Application.ServiceExceptions;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Application.Services;

public class EmailTypeService : IEmailTypeService
{
    private readonly IEmailTypeRepository emailTypeRepository;
    private readonly IRepository<UserProfile> userProfileRepository;
    private readonly ILogger<EmailTypeService> logger;
    private readonly IMapper mapper;

    public EmailTypeService(
        IEmailTypeRepository emailTypeRepository,
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

    public async Task Delete(EmailType emailType)
    {
        var dbEmailType = await emailTypeRepository.GetAll()
            .FirstOrDefaultAsync(x => x.Id == emailType.Id);

        if (dbEmailType == null)
        {
            throw new EmailException($"Email type with id={emailType.Id} not found");
        }
        
        await emailTypeRepository.DeleteAsync(dbEmailType);
    }

    public async Task<List<UserProfile>> Get(string id)
    {
        var dbEmaiType = await emailTypeRepository.GetAll()
            .FirstOrDefaultAsync(x => x.Id == id);

        if (dbEmaiType == null)
        {
            throw new EmailException($"Email type with id={id} not found");
        }
        
        //Не рабочая заглушка
        var userProfiles = await GetUserProfiles(dbEmaiType);

        return userProfiles;
    }

    public Task<List<UserProfile>> GetEmailsType(EmailTypeSearchDTO emailType)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EmailType>> GetAll()
    {
        throw new NotImplementedException();
    }

    private async Task<List<UserProfile>> GetUserProfiles(EmailType emailType)
    {
        throw new NotImplementedException();
    }
}