using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileOutlook.Core
{
    public class ServiceRegistrar
    {
        static IDictionary<Type, object> services;
        static ServiceRegistrar()
        {
            services = new Dictionary<Type, object>();

        }
        public static void RegisterService(Type t, object objectToRegister)
        {
            services.Add(t, objectToRegister);
        }

        public static void UnRegisterService(Type t)
        {
            if (services.ContainsKey(t))
            {
                services.Remove(t);
            }
        }

        public static T GetService<T>()
        {
            return (T)services[typeof(T)];
        }
    }
}
