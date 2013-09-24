
namespace Domain.Events.Console
{
    using Autofac;
    using Autofac.Extensions;
    using global::Autofac;
    using Model;
    using Model.EventHandlers;
    using Model.Events;

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterDomainEventHandler<UserAccountCreated, UserAccountCreatedHandler>();
            var container = builder.Build();

            DomainEventChannel.Dispatcher = new AutofacDomainEventDispatcher(container);

            UserAccount.Create("username", "user@email.com", "password");

            System.Console.ReadKey();
        }
    }
}
