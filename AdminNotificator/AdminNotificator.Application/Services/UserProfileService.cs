using AdminNotificator.Application.Common;
using AdminNotificator.Application.Models.EmailType;
using AdminNotificator.Application.Models.UserProfile;
using AdminNotificator.Application.ServiceExceptions;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Application.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IRepository<UserProfile> userProfileRepository;
    private readonly ILogger<UserProfile> logger;
    private readonly IMapper mapper;

    public UserProfileService(IRepository<UserProfile> userProfileRepository, ILogger<UserProfile> logger, IMapper mapper)
    {
        this.userProfileRepository = userProfileRepository;
        this.logger = logger;
        this.mapper = mapper;
    }

    public async Task<string> Add(UserProfileAddDTO dto)
    {
        var entity = mapper.Map<UserProfileAddDTO, UserProfile>(dto);
        await userProfileRepository.AddAsync(entity);
        logger.Log(LogLevel.Information, "User profile added");
        return entity.Id;
    }

    public async Task Update(UserProfileUpdateDTO dto)
    {
        var entity = mapper.Map<UserProfileUpdateDTO, UserProfile>(dto);
        await userProfileRepository.UpdateAsync(entity);
        logger.Log(LogLevel.Information, "User profile updated");
    }

    public async Task Delete(UserProfileDeleteDTO dto)
    {
        var dbEmailType = userProfileRepository.GetAll()
            .FirstOrDefault(x => x.Id == dto.Id);

        if (dbEmailType == null)
        {
            var message = $"User profile with id={dto.Id} not found";
            logger.Log(LogLevel.Warning, message);
            throw new EmailException(message);
        }

        logger.Log(LogLevel.Information, "User profile deleted");
        await userProfileRepository.DeleteAsync(dbEmailType);
    }

    public async Task<UserProfileGetDTO> Get(string id)
    {
        var entity = userProfileRepository.GetAll().FirstOrDefault(x => x.Id == id);
        logger.Log(LogLevel.Information, "User profile get");
        return mapper.Map<UserProfile, UserProfileGetDTO>(entity);
    }

    public async Task<PaginatedList<UserProfileGetDTO>> GetAll(int pageIndex, int pageSize)
    {
        var entities = await userProfileRepository
            .GetAll(pageIndex, pageSize)
            .Select(x => mapper.Map<UserProfile, UserProfileGetDTO>(x))
            .ToListAsync();
        logger.Log(LogLevel.Information, "User profiles get");
        return new PaginatedList<UserProfileGetDTO>(entities, pageIndex, pageSize);
    }
}