
namespace Domain.Events.Model.EventHandlers
{
    using Events;

    public class UserAccountCreatedHandler : IDomainEventHandler<UserAccountCreated>
    {
        public void When(UserAccountCreated @event)
        {
            @event.UserAccount.EmailSent = true;

            System.Console.WriteLine("Sent welcome email to user with id: {0}", @event.UserAccount.Id);
        }
    }
}
