using AdminNotificator.Core.Domain;
using AdminNotificator.Core.TablesConfigration;
using Microsoft.EntityFrameworkCore;

namespace AdminNotificator.Core;

public class AdminNotificatorDbContext : DbContext
{
    public AdminNotificatorDbContext(DbContextOptions<AdminNotificatorDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<EmailType> EmailTypes { get; set; }
    
    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new EmailTypeConfiguration());
        builder.ApplyConfiguration(new UserProfileConfiguration());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
        optionsBuilder.UseInMemoryDatabase("AdminDb"); 
    } 
}