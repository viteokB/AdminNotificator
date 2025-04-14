using AdminNotificator.Application.Models.EmailType;
using AdminNotificator.Application.Common;
using AdminNotificator.Core.Domain;

namespace AdminNotificator.Application.Services;

public interface IEmailTypeService
{
    public Task<string> Add(EmailTypeAddDTO emailType);

    public Task Update(EmailTypeUpdateDTO emailType);

    public Task Delete(EmailTypeDeleteDTO emailType);

    public Task<UserProfile> Get(int id);

    public Task<List<UserProfile>> GetEmailsType(EmailTypeSearchDTO emailType);

    public Task<PaginatedList<EmailTypeGetDTO>> GetAll(int pageIndex, int pageSize);
}