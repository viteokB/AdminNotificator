using System.Linq.Expressions;
using AdminNotificator.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminNotificator.Core.Repositories;

public class EmailTypeRepository(AdminNotificatorDbContext dbContext) : IEmailTypeRepository
{
    public IQueryable<EmailType> GetAll()
    {
        return dbContext.EmailTypes;
    }

    public IQueryable<EmailType> GetAll(int pageIndex, int pageSize)
    {
        return dbContext.EmailTypes.Skip(pageIndex * pageSize).Take(pageSize);
    }

    public async Task AddAsync(EmailType item, CancellationToken cancellationToken = default)
    {
        await dbContext.AddAsync(item, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AddAllAsync(IEnumerable<EmailType> entities, CancellationToken cancellationToken = default)
    {
        await dbContext.AddRangeAsync(entities, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(EmailType item, CancellationToken cancellationToken = default)
    {
        dbContext.UpdateRange(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(EmailType item, CancellationToken cancellationToken = default)
    {
        dbContext.Remove(item);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(IEnumerable<EmailType> items, CancellationToken cancellationToken = default)
    {
        dbContext.RemoveRange(items);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAllAsync(Expression<Func<EmailType, bool>> predicate, CancellationToken cancellationToken = default)
    {
        dbContext.EmailTypes.RemoveRange(dbContext.EmailTypes.Where(predicate));
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public IEnumerable<UserProfile> FilterByEmailType(IQueryable<UserProfile> query, EmailType searchDto)
    {
        if (searchDto == null)
            return query;

        // Фильтр по стажу (количеству дней в компании)
        if (searchDto.ExperianceDays.HasValue)
        {
            query = query.Where(u => u.ExperienceDays.HasValue &&
                                   u.ExperienceDays.Value == searchDto.ExperianceDays.Value);
        }

        // Фильтр по отделам (включение)
        if (searchDto.IntersectDepartmentIds != null && searchDto.IntersectDepartmentIds.Any())
        {
            query = query.Where(u => u.DepartmentIds.Any(d => searchDto.IntersectDepartmentIds.Contains(d)));
        }

        // Фильтр по отделам (исключение)
        if (searchDto.ExceptDepartmentIds != null && searchDto.ExceptDepartmentIds.Any())
        {
            query = query.Where(u => !u.DepartmentIds.Any(d => searchDto.ExceptDepartmentIds.Contains(d)));
        }

        // Фильтр по организациям
        if (searchDto.IntersectOrganizationNames != null && searchDto.IntersectOrganizationNames.Any())
        {
            query = query.Where(u => u.UserPositions.Any(p =>
                searchDto.IntersectOrganizationNames.Contains(p.OrganizationShortname)));
        }

        // Фильтр по городам (включение)
        if (searchDto.IntersectTowns != null && searchDto.IntersectTowns.Any())
        {
            query = query.Where(u => u.UserOffice != null &&
                                   searchDto.IntersectTowns.Contains(u.UserOffice.Town));
        }

        // Фильтр по городам (исключение)
        if (searchDto.ExceptTowns != null && searchDto.ExceptTowns.Any())
        {
            query = query.Where(u => u.UserOffice == null ||
                                   !searchDto.ExceptTowns.Contains(u.UserOffice.Town));
        }

        // Фильтр по декретному отпуску
        if (searchDto.MaternityDays.HasValue && searchDto.MaternityDays > 0)
        {
            query = query.Where(u => u.MaternityLeaveDate.HasValue &&
                                   u.UserStatus == UserStatus.MaternityLeave &&
                                   (DateTime.UtcNow - u.MaternityLeaveDate.Value).TotalDays >= searchDto.MaternityDays.Value);
        }

        // Фильтр по полу
        if (searchDto.ForGenders != null && searchDto.ForGenders.Any())
        {
            var genders = searchDto.ForGenders
                .Select(g => Enum.Parse<UserGender>(g, true))
                .ToList();

            query = query.Where(u => genders.Contains(u.UserGender));
        }

        // Фильтр по должностям (включение)
        if (searchDto.IntersectUserPosts != null && searchDto.IntersectUserPosts.Any())
        {
            query = query.Where(u => u.UserPositions.Any(p =>
                searchDto.IntersectUserPosts.Contains(p.Post)));
        }

        // Фильтр по должностям (исключение)
        if (searchDto.ExceptUserPosts != null && searchDto.ExceptUserPosts.Any())
        {
            query = query.Where(u => !u.UserPositions.Any(p =>
                searchDto.ExceptUserPosts.Contains(p.Post)));
        }

        return query;
    }

    public async Task<EmailType?> GetEmailTypeById(string id)
    {
        return await dbContext.EmailTypes.FirstOrDefaultAsync(u => u.Id == id);
    }
}