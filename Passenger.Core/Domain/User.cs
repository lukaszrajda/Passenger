using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {
        private readonly Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public Guid Id { get; protected set; }
        public string Email {get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        protected User()
        {  
        }

        public User(Guid userId, string email, string username,
            string password, string salt)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new DomainException($"Username is empty.");
            }
            Id = Guid.NewGuid();
            SetEmail(email);
            SetUserName(username);
            SetPassword(password);
            Id = userId;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }
        public void SetEmail(string email)
        {
            if (!EmailRegex.IsMatch(email))
            {
                throw new DomainException(ErrorCodes.InvalidEmail, $"Email adress {email} is not valid email adress.");
            }
            if (email == Email)
            {
                return;
            }
            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetUserName(string userName)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new DomainException(ErrorCodes.InvalidUsername,"UserName can not be empty.");
            }
            if (userName == UserName)
            {
                return;
            }
            UserName = userName.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetPassword(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                throw new DomainException(ErrorCodes.InvalidPassword ,"Password is empty.");
            }
            if (password == Password)
            {
                return;
            }
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetRole(string role)
        {
            if (String.IsNullOrEmpty(role))
            {
                throw new DomainException(ErrorCodes.InvalidRole, $"Role is empty.");
            }
            if (role == Role)
            {
                return;
            }
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }
    }


}