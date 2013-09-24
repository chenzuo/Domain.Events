using System;

namespace Domain.Events.Model
{
    using Events;

    public class UserAccount
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool EmailSent { get; internal set; }

        private UserAccount(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public static UserAccount Create(string userName, string email, string password)
        {
            var userAccount = new UserAccount(userName, email, password) { Id = Guid.NewGuid() };

            DomainEventChannel.Raise(new UserAccountCreated(userAccount));

            return userAccount;
        }
    }
}
