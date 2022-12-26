using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public static class DiContainer
    {
        private static Dictionary<Type, object> _dictionary = new Dictionary<Type, object>();

        public static void RegisterType<TService>(TService obj) 
        {
            _dictionary.Add(typeof(TService), obj);        
        }

        public static TService GetInstance<TService>() where TService : class
        {
            return _dictionary[typeof(TService)] as TService;
        }
    }
}