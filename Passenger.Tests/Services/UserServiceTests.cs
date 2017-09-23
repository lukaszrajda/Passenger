using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using Xunit;

namespace Passenger.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Encrypter _encrypter;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserService _userService;
        private readonly static string Email = "user@rmail.com";
        private readonly static string Username = "user";
        private readonly static string Password = "secret";
        private readonly static string Role = "user";
        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _encrypter = new Encrypter();
            _mapperMock = new Mock<IMapper>();
            _userService = new UserService(_userRepositoryMock.Object, _encrypter, _mapperMock.Object);

        }
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            await _userService.RegisterAsync(Guid.NewGuid(), Email, Username, Password, Role);
            _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
        [Fact]
        public async Task get_async_with_email_should_give_user_with_same_email()
        {
            await _userService.RegisterAsync(Guid.NewGuid(), Email, Username, Password, Role);
            var user = await _userService.GetAsync(Email);
        }
    }
}