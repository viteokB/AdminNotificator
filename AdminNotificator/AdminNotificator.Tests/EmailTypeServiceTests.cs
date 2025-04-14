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
    private readonly IRepository<EmailType> fakeRepo;
    private readonly IRepository<UserProfile> fakeUserProvider;
    private readonly ILogger<EmailTypeService> fakeLogger;
    private readonly IMapper fakeMapper;
    private readonly IEmailTypeService service;

    public EmailTypeServiceTests()
    {
        fakeRepo = A.Fake<IRepository<EmailType>>();
        fakeLogger = A.Fake<ILogger<EmailTypeService>>();
        service = new EmailTypeService(fakeRepo, fakeUserProvider, fakeLogger, fakeMapper);
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
    public async Task Delete_NullEmailType_ShouldThrowArgumentNullException()
    {
        Func<Task> act = async () => await service.Delete(null);

        await act.Should().ThrowAsync<ServiceException>();
    }

    [Test]
    public async Task Get_NegativeId_ShouldReturnNull()
    {
        var result = await service.Get(-1);

        result.Should().BeNull();
    }
}