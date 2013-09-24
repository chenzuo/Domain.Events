using System;
using System.Collections.Generic;

namespace Domain.Events.Facts
{
    public class TestDomainEventDispatcher : IDomainEventDispatcher, IDisposable
    {
        private IDictionary<Type, Delegate> _handlers;

        public TestDomainEventDispatcher()
        {
            _handlers = new Dictionary<Type, Delegate>();
        }

        public void Register<TDomainEvent>(Action<TDomainEvent> eventAction) where TDomainEvent : IDomainEvent
        {
            _handlers.Add(typeof(TDomainEvent), eventAction);
        }

        public void Dispatch<TDomainEvent>(TDomainEvent eventToDispatch) where TDomainEvent : IDomainEvent
        {
            if (!_handlers.ContainsKey(typeof(TDomainEvent))) return;

            var handler = (Action<TDomainEvent>)_handlers[typeof(TDomainEvent)];

            handler.Invoke(eventToDispatch);
        }

        public void Dispose()
        {
            _handlers = null;
        }
    }
}
