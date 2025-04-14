using AdminNotificator.Application.Models.UserProfile;
using AdminNotificator.Application.ServiceExceptions;
using AdminNotificator.Application.Services;
using AdminNotificator.Core.Domain;
using AdminNotificator.Core.Repositories;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace AdminNotificator.Tests;

[TestFixture]
public class UserProfileServiceTests
{
    private IRepository<UserProfile> _fakeUserProfileRepository;
    private ILogger<UserProfile> _fakeLogger;
    private IMapper _fakeMapper;
    private UsersFilter _usersFilter;
    private UserProfileService _service;

    [SetUp]
    public void SetUp()
    {
        _fakeUserProfileRepository = A.Fake<IRepository<UserProfile>>();
        _fakeLogger = A.Fake<ILogger<UserProfile>>();
        _fakeMapper = A.Fake<IMapper>();

        // UsersFilter зависит от IRepository<UserProfile>, поэтому передаём фейк вручную
        _usersFilter = new UsersFilter(_fakeUserProfileRepository);

        _service = new UserProfileService(_fakeUserProfileRepository, _fakeLogger, _fakeMapper, _usersFilter);
    }

    [Test]
    public async Task Add_Should_Add_UserProfile_When_Valid()
    {
        var dto = A.Fake<UserProfileAddDTO>();
        var profile = A.Fake<UserProfile>();
        A.CallTo(() => _fakeMapper.Map<UserProfile>(dto)).Returns(profile);

        var result = await _service.Add(dto);

        A.CallTo(() => _fakeUserProfileRepository.AddAsync(profile, default)).MustHaveHappened();
        result.Should().Be(profile.Id);
    }

    [Test]
    public async Task Add_Should_Throw_If_DTO_Null()
    {
        Func<Task> act = async () => await _service.Add(null);
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task Add_Should_Throw_If_Login_Null()
    {
        var dto = new UserProfileAddDTO { Login = null }; 
        A.CallTo(() => _fakeMapper.Map<UserProfile>(dto)).Throws<ArgumentException>();

        Func<Task> act = async () => await _service.Add(dto);
        await act.Should().ThrowAsync<ArgumentException>();
    }


    [Test]
    public async Task Update_Should_Update_UserProfile_When_Valid()
    {
        var dto = A.Fake<UserProfileUpdateDTO>();
        var entity = A.Fake<UserProfile>();
        A.CallTo(() => _fakeMapper.Map<UserProfile>(dto)).Returns(entity);

        await _service.Update(dto);

        A.CallTo(() => _fakeUserProfileRepository.UpdateAsync(entity, default)).MustHaveHappened();
    }

    [Test]
    public async Task Update_Should_Throw_If_DTO_Null()
    {
        Func<Task> act = async () => await _service.Update(null);
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task Update_Should_Throw_If_MappedEntity_Sid_Is_Null()
    {
        // Arrange
        var dto = new UserProfileUpdateDTO(); 
        var userProfile = A.Fake<UserProfile>();
        A.CallTo(() => userProfile.Sid).Returns(null as string); 
        A.CallTo(() => _fakeMapper.Map<UserProfile>(dto)).Returns(userProfile);

        Func<Task> act = async () => await _service.Update(dto);

        await act.Should().ThrowAsync<ArgumentException>().WithMessage("Sid is required");
    }

    [Test]
    public async Task Delete_Should_Remove_UserProfile_When_Exists()
    {
        var dto = new UserProfileDeleteDTO { Id = "123" };
        var profile = A.Fake<UserProfile>();
        A.CallTo(() => _fakeUserProfileRepository.GetAll()).Returns(new List<UserProfile> { profile }.AsQueryable());
        A.CallTo(() => profile.Id).Returns("123");

        await _service.Delete(dto);

        A.CallTo(() => _fakeUserProfileRepository.DeleteAsync(profile, default)).MustHaveHappened();
    }

    [Test]
    public async Task Delete_Should_Throw_If_DTO_Null()
    {
        Func<Task> act = async () => await _service.Delete(null);
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task Delete_Should_Throw_If_Profile_Not_Found()
    {
        var dto = new UserProfileDeleteDTO { Id = "123" };
        A.CallTo(() => _fakeUserProfileRepository.GetAll()).Returns(new List<UserProfile>().AsQueryable());

        Func<Task> act = async () => await _service.Delete(dto);
        await act.Should().ThrowAsync<EmailException>()
            .WithMessage("User profile with id=123 not found");
    }


    [Test]
    public async Task Get_Should_Return_UserProfileGetDTO_When_Found()
    {
        var profile = A.Fake<UserProfile>();
        var dto = A.Fake<UserProfileGetDTO>();
        A.CallTo(() => profile.Id).Returns("123");
        A.CallTo(() => _fakeUserProfileRepository.GetAll()).Returns(new List<UserProfile> { profile }.AsQueryable());
        A.CallTo(() => _fakeMapper.Map<UserProfileGetDTO>(profile)).Returns(dto);

        var result = await _service.Get("123");

        result.Should().Be(dto);
    }

    [Test]
    public async Task Get_Should_Throw_If_Id_Null()
    {
        Func<Task> act = async () => await _service.Get(null);
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task Get_Should_Return_Null_If_Not_Found()
    {
        A.CallTo(() =>_fakeUserProfileRepository.GetAll()).Returns(new List<UserProfile>().AsQueryable());

        var result = await _service.Get("nonexistent");

        result.Should().BeNull();
    }

    [Test]
    public async Task GetAll_Should_Return_PaginatedList()
    {
        var profile = A.Fake<UserProfile>();
        var dto = A.Fake<UserProfileGetDTO>();
        A.CallTo(() => _fakeUserProfileRepository.GetAll(0, 10)).Returns(new List<UserProfile> { profile }.AsQueryable());
        A.CallTo(() => _fakeMapper.Map<UserProfileGetDTO>(profile)).Returns(dto);

        var result = await _service.GetAll(0, 10);

        result.Items.Should().ContainSingle(x => x == dto);
    }

    [Test]
    public async Task GetAll_Should_Throw_If_PageSize_Is_Zero()
    {
        Func<Task> act = async () => await _service.GetAll(0, 0);
        await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
    }

    [Test]
    public async Task GetAll_Should_Return_Empty_When_None()
    {
        A.CallTo(() => _fakeUserProfileRepository.GetAll(0, 10)).Returns(new List<UserProfile>().AsQueryable());

        var result = await _service.GetAll(0, 10);

        result.Items.Should().BeEmpty();
    }
}