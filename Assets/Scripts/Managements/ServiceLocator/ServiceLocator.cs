using System;
using System.Collections.Generic;

namespace ServiceLocatorPattern
{
    public class ServiceLocator
    {
        private static readonly IDictionary<Type, Object> Services = new Dictionary<Type, Object>();

        public static void RegisterService<T>(T service)
        {
            if (!Services.ContainsKey(typeof(T))) Services[typeof(T)] = service;
            else throw new ApplicationException("Service Already Registered");
        }

        public static T GetService<T>()
        {
            try
            {
                return (T)Services[typeof(T)];
            }
            catch
            {
                throw new ApplicationException("Requested Service not Found");
            }
        }
    }
}