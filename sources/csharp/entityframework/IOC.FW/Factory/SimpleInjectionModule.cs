using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleInjector;
using System.Collections.Specialized;
using System.Configuration;
using IOC.FW.Abstraction.Factory;
using IOC.FW.Abstraction.Binding;

namespace IOC.FW.Factory
{
    public class SimpleInjectionModule
    : IInjectionModule<SimpleInjector.Container>
    {
        public Container container { get; set; }

        public SimpleInjectionModule()
        {
            this.container = new Container();
            this.Load();
        }

        private void Load()
        {
            var injectionFactoryGroup = (ConfigurationManager.GetSection("InjectionFactoryGroup/InjectionFactory") as NameValueCollection);

            if (injectionFactoryGroup != null && injectionFactoryGroup.Count > 0)
            {
                for (int i = 0; i < injectionFactoryGroup.Count; i++)
                {
                    string assembly = injectionFactoryGroup.GetValues(i).FirstOrDefault();
                    string[] assemblies = assembly.Split(',');

                    if (assemblies != null && assemblies.Length >= 1)
                    {
                        var instance = Activator.CreateInstance(assemblies[0].Trim(), assemblies[1].Trim());
                        var module = (IModule)instance.Unwrap();

                        if (module is IModule)
                        {
                            module.SetBinding(this.container);
                        }
                    }
                }
            }
        }

        public Container GetInjection()
        {
            return this.container;
        }

        public TImplementation GetImplementation<TImplementation>()
            where TImplementation : class
        {
            var injection = GetInjection();
            return injection.GetInstance<TImplementation>();
        }
    }
}
