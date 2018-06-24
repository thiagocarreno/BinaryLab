using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleInjector;

namespace IOC.FW.Factory
{
    public class InstanceFactory
    {
        private static volatile Container container;

        private static Container GetInjection()
        {
            if (container == null)
            {
                var module = new SimpleInjectionModule();
                container = (Container)module.container;
                container.Verify();
            }

            return container;
        }

        public static T GetImplementation<T>()
            where T : class
        {
            var injection = GetInjection();
            return injection.GetInstance<T>();
        }

        public static Container RegisterModules()
        {
            return GetInjection();
        }
    }
}
