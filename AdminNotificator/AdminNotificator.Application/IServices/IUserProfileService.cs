using AdminNotificator.Application.Common;
using AdminNotificator.Application.Models.UserProfile;
using AdminNotificator.Core.Domain;

namespace AdminNotificator.Application.Services;

public interface IUserProfileService
{
    public Task<string> Add(UserProfileAddDTO dto);
    public Task Update(UserProfileUpdateDTO dto);
    public Task Delete(UserProfileDeleteDTO dto);
    public Task<UserProfileGetDTO> Get(string id);
    public Task<PaginatedList<UserProfileGetDTO>> GetAll(int pageIndex, int pageSize);
}