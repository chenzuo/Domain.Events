
namespace Domain.Events.Facts
{
    using Model;
    using Model.EventHandlers;
    using Model.Events;
    using Xunit;

    public class DomainEventChannelFacts
    {
        [Fact]
        public void when_user_account_created_event_is_raised_and_handled_email_sent_is_true()
        {
            // Arrange
            UserAccount userAccount;

            // Act
            using (var dispatcher = new TestDomainEventDispatcher())
            {
                var handler = new UserAccountCreatedHandler();
                dispatcher.Register<UserAccountCreated>(handler.When);

                DomainEventChannel.Dispatcher = dispatcher;

                userAccount = UserAccount.Create("username", "user@email.com", "password");
            }

            // Assert
            Assert.True(userAccount.EmailSent);
        }

        [Fact]
        public void when_user_account_created_event_is_raised_and_unhandled_email_sent_is_false()
        {
            // Arrange
            UserAccount userAccount;

            // Act
            using (var dispatcher = new TestDomainEventDispatcher())
            {
                DomainEventChannel.Dispatcher = dispatcher;

                userAccount = UserAccount.Create("username", "user@email.com", "password");
            }

            // Assert
            Assert.False(userAccount.EmailSent);
        }
    }
}
