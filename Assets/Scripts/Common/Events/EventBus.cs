using System;
using System.Collections.Generic;

namespace Common.Events
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<Object>> _subscribers = new();

        public void Subscribe<T>(Action<T> handler)
        {
            if (!_subscribers.ContainsKey(typeof(T)))
            {
                _subscribers[typeof(T)] = new List<Object>();
            }
            
            _subscribers[typeof(T)].Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            if (_subscribers.TryGetValue(typeof(T), out var handlers))
            {
                handlers.Remove(handler);
            }
        }

        public void Publish<T>(T eventData)
        {
            if (!_subscribers.TryGetValue(typeof(T), out var handlers))
            {
                foreach (var handler in handlers)
                {
                    ((Action<T>)handler)?.Invoke(eventData);
                }
            }
        }
    }
}