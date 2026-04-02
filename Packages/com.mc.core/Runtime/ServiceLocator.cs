using System;
using System.Collections.Generic;

namespace MC.Core
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> Services = new();

        public static void Register<T>(T service) where T : class
        {
            Services[typeof(T)] = service ?? throw new ArgumentNullException(nameof(service));
        }

        private static bool TryGet<T>(out T service) where T : class
        {
            if (Services.TryGetValue(typeof(T), out var obj))
            {
                service = (T)obj;
                return true;
            }

            service = null;
            return false;
        }

        public static T Get<T>() where T : class
        {
            return TryGet<T>(out var service) 
                ? service 
                : throw new KeyNotFoundException($"Service of type {typeof(T).Name} not registered.");
        }

        public static void Unregister<T>()
        {
            var type = typeof(T);
            if (!Services.Remove(type))
            {
                throw new KeyNotFoundException($"Service of type {type.Name} not registered.");
            }
        }

        /// <summary>
        /// Clears all registered services from the locator.
        /// Useful for unit testing to ensure isolation between tests.
        /// </summary>
        public static void Clear() => Services.Clear();
    }
}
