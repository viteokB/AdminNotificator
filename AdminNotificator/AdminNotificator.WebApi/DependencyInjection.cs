using AdminNotificator.Application.IServices;
using AdminNotificator.Application.Services;
using AdminNotificator.Core;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdminNotificator.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailTypeService, EmailTypeService>();
        services.AddScoped<IUserProfileService, UserProfileService>();
        
        return services;
    }

    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddDbContext<DbContext, AdminNotificatorDbContext>();

        services.AddScoped<IEmailTypeRepository, EmailTypeRepository>();
        services.AddScoped<IRepository<UserProfile>, UserProfileRepository>();
        
        return services;
    }
}