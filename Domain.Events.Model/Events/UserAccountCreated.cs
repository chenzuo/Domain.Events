
namespace Domain.Events.Model.Events
{
    public class UserAccountCreated : IDomainEvent
    {
        public UserAccount UserAccount { get; private set; }

        public UserAccountCreated(UserAccount userAccount)
        {
            UserAccount = userAccount;
        }
    }
}
