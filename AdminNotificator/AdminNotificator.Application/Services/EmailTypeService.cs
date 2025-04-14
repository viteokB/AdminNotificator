using AdminNotificator.Application.Common;
using AdminNotificator.Application.Models.EmailType;
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

    public async Task Delete(EmailTypeDeleteDTO dto)
    {
        var dbEmailType = await emailTypeRepository.GetAll()
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (dbEmailType == null)
        {
            throw new EmailException($"Email type with id={dto.Id} not found");
        }

        await emailTypeRepository.DeleteAsync(dbEmailType);
    }

    public Task<UserProfile> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserProfile>> GetEmailsType(EmailTypeSearchDTO emailType)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedList<EmailTypeGetDTO>> GetAll(int pageIndex, int pageSize)
    {
        var emailTypes = await emailTypeRepository
            .GetAll(pageIndex, pageSize)
            .Select(x => mapper.Map<EmailType, EmailTypeGetDTO>(x))
            .ToListAsync();

        return new PaginatedList<EmailTypeGetDTO>(emailTypes, pageIndex, pageSize);
    }
    public Task<IEnumerable<UserProfile>> GetUserProfilesByEmailType(int id)
    {
        throw new NotImplementedException();
    }
}