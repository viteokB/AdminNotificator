using System.Diagnostics;
using AdminNotificator.Application.Common;
using AdminNotificator.Application.Models.UserProfile;
using AdminNotificator.Application.ServiceExceptions;
using AdminNotificator.Application.Services.Filters;
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
    private readonly AllFilters allFilters;

    public UserProfileService(IRepository<UserProfile> userProfileRepository, ILogger<UserProfile> logger, AllFilters allFilters, IMapper mapper)
    {
        this.userProfileRepository = userProfileRepository;
        this.logger = logger;
        this.allFilters = allFilters;
    }

    public async Task<string> Add(UserProfileAddDTO dto)
    {
        ThrowExceptionAndLogIfNull(dto);

        var entity = mapper.Map<UserProfileAddDTO, UserProfile>(dto);

        ThrowExceptionAndLogIfNull(dto.Login);

        await userProfileRepository.AddAsync(entity);
        logger.Log(LogLevel.Information, "User profile added");
        return entity.Id;
    }

    public async Task Update(UserProfileUpdateDTO dto)
    {
        ThrowExceptionAndLogIfNull(dto);

        var entity = mapper.Map<UserProfileUpdateDTO, UserProfile>(dto);

        ThrowExceptionAndLogIfNull(entity.Sid);

        await userProfileRepository.UpdateAsync(entity);
        logger.Log(LogLevel.Information, "User profile updated");
    }

    private void ThrowExceptionAndLogIfNull<T>(T dto)
    {
        if (dto is not null)
            return;

        logger.LogWarning($"User profile is null");
        throw new ArgumentNullException();
    }

    public async Task Delete(UserProfileDeleteDTO dto)
    {
        ThrowExceptionAndLogIfNull(dto);

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

        ThrowExceptionAndLogIfNull(entity);

        logger.Log(LogLevel.Information, "User profile get");
        return mapper.Map<UserProfile, UserProfileGetDTO>(entity);
    }

    public async Task<PaginatedList<UserProfileGetDTO>> GetAll(int pageIndex, int pageSize)
    {
        if (pageSize <= 0)
        {
            logger.LogWarning("page size can't be less or equal 0");
            throw new ArgumentOutOfRangeException();
        }

        var entities = await userProfileRepository
            .GetAll(pageIndex, pageSize)
            .Select(x => mapper.Map<UserProfile, UserProfileGetDTO>(x))
            .ToListAsync();
        logger.Log(LogLevel.Information, "User profiles get");
        return new PaginatedList<UserProfileGetDTO>(entities, pageIndex, pageSize);
    }

    public async Task<IEnumerable<UserProfile>> GetUsersWithAllFilters(EmailType emailType)
    {
        HashSet<UserProfile> filteredUers = new HashSet<UserProfile>();
        foreach (var filter in allFilters.GetUserFilters())
        {
            var filtered = await filter.GetUserByFilter(emailType);
            if (filtered != null)
            {
                filteredUers.IntersectWith(filtered);
            }
        }

        return filteredUers.AsEnumerable();
    }
}
