using AdminNotificator.Application.ServiceExceptions;
using AdminNotificator.Application.Services;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Tests;

[TestFixture]
public class UserProfileServiceTests
{
    private IRepository<UserProfile> _fakeUserProfileRepository;
    private ILogger<UserProfile> _fakeLogger;
    private UserProfileService _service;

    [SetUp]
    public void SetUp()
    {
        _fakeUserProfileRepository = A.Fake<IRepository<UserProfile>>();
        _fakeLogger = A.Fake<ILogger<UserProfile>>();
        _service = new UserProfileService(_fakeUserProfileRepository, _fakeLogger);
    }

    [Test]
    public async Task Add_NullUserProfile_ShouldThrowServiceException()
    {
        Func<Task> act = async () => await _service.Add(null);
        await act.Should().ThrowAsync<ServiceException>();
    }

    [Test]
    public async Task Update_NullUserProfile_ShouldThrowServiceException()
    {
        Func<Task> act = async () => await _service.Update(null);
        await act.Should().ThrowAsync<ServiceException>();
    }

    [Test]
    public async Task Delete_NullUserProfile_ShouldThrowServiceException()
    {
        Func<Task> act = async () => await _service.Delete(null);
        await act.Should().ThrowAsync<ServiceException>();
    }

    [Test]
    public async Task Get_InvalidId_ShouldReturnNull()
    {
        var result = await _service.Get(-10);
        result.Should().BeNull();
    }
}
