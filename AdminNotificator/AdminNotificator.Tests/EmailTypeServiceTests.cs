using AdminNotificator.Application.IServices;
using AdminNotificator.Application.Models.EmailType;
using AdminNotificator.Application.ServiceExceptions;
using AdminNotificator.Application.Services;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Tests;

class EmailTypeServiceTests
{
    private readonly IEmailTypeRepository fakeRepo;
    private readonly IRepository<UserProfile> fakeUserProvider;
    private readonly ILogger<EmailTypeService> fakeLogger;
    private readonly IMapper fakeMapper;
    private readonly IEmailTypeService service;

    public EmailTypeServiceTests()
    {
        fakeRepo = A.Fake<IEmailTypeRepository>();
        fakeLogger = A.Fake<ILogger<EmailTypeService>>();
        service = new EmailTypeService(fakeRepo, fakeUserProvider, fakeLogger, fakeMapper);
    }
    
    [Test]
    public async Task Add_ValidDto_ShouldAddAndReturnId()
    {
        var dto = new EmailTypeAddDTO
        {
            EmailTitle = "Test",
            BodyName = "Body",
            SenderEmail = "sender@example.com"
        };

        var result = await service.Add(dto);
        
        A.CallTo(() => fakeLogger.Log(LogLevel.Information, "email type added")).MustHaveHappened();
    }
    
    [Test]
    public async Task Add_NullEmailType_ShouldThrowArgumentNullException()
    {
        Func<Task> act = async () => await service.Add(null);

        await act.Should().ThrowAsync<ServiceException>();
    }
    
    [Test]
    public async Task Update_NullEmailType_ShouldThrowArgumentNullException()
    {
        Func<Task> act = async () => await service.Update(null);

        await act.Should().ThrowAsync<ServiceException>();
    }
    
    [Test]
    public async Task Update_ValidDto_ShouldUpdate()
    {
        var dto = new EmailTypeUpdateDTO
        {
            EmailTitle = "Update",
            BodyName = "Body",
            SenderEmail = "sender@example.com"
        };

        await service.Update(dto);
        
        A.CallTo(() => fakeLogger.Log(LogLevel.Information, "email type updated")).MustHaveHappened();
    }
    
    [Test]
    public async Task Delete_ShouldThrowServiceException_WhenDtoIsNull()
    {
        var act = async () => await service.Delete(null);
        
        await act.Should()
            .ThrowAsync<ServiceException>()
            .WithMessage("dto is null");
    }

    [Test]
    public async Task Delete_ShouldCallDeleteAsync_WhenEmailTypeExists()
    {
        var addDto = new EmailTypeAddDTO { EmailTitle = "Test", BodyName = "Body", SenderEmail = "sender@example.com" };
        var addedId = await service.Add(addDto);
        var deleteDto = new EmailTypeDeleteDTO { Id = addedId };
        var act = async () => await service.Delete(deleteDto);
        await act.Should().NotThrowAsync();
    }
    
    [Test]
    public async Task Get_NegativeId_ShouldReturnNull()
    {
        Func<Task> act = async () => await service.Get("-1");

        await act.Should().ThrowAsync<ServiceException>();
    }
}