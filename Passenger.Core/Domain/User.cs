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
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        protected User()
        {  
        }

        public User(string email, string username,
            string password, string salt)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new Exception($"Username is empty.");
            }
            Id = Guid.NewGuid();
            SetEmail(email);
            SetUserName(username);
            SetPassword(password);
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }
        public void SetEmail(string email)
        {
            if (!EmailRegex.IsMatch(email))
            {
                throw new Exception($"Email adress {email} is not valid email adress.");
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
                throw new Exception($"UserName is empty.");
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
                throw new Exception($"Password is empty.");
            }
            if (password == Password)
            {
                return;
            }
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
    }


}