using System.Threading.Tasks;
using Passenger.Infrastructure.Services;
using Xunit;

namespace Passenger.Tests.Services
{
    public class EncrypterTests
    {
        private readonly Encrypter _encrypter = new Encrypter();

        public EncrypterTests()
        {

        } 
        
        [Fact]
        public void given_string_should_give_hash()//register_async_should_invoke_add_async_on_repository()
        {
            var password = "secret";
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password,salt);
            Assert.False(string.Equals(password,hash));
        }      

        [Fact]
        public void given_different_password_and_the_same_salt_should_be_different_hash()//register_async_should_invoke_add_async_on_repository()
        {

            var password1 = "secret1";
            var password2 = "secret2";
            var salt = _encrypter.GetSalt(password1);
            var hash1 = _encrypter.GetHash(password1,salt);
            var hash2 = _encrypter.GetHash(password2,salt);
            Assert.False(string.Equals(hash1,hash2));
        }   

        [Fact]
        public void given_the_same_password_and_the_same_salt_should_be_the_same_hash()//register_async_should_invoke_add_async_on_repository()
        {
            var password1 = "secret";
            var password2 = "secret";
            var salt = _encrypter.GetSalt(password1);
            var hash1 = _encrypter.GetHash(password1,salt);
            var hash2 = _encrypter.GetHash(password2,salt);
            Assert.True(string.Equals(hash1,hash2));
        } 
    }
}