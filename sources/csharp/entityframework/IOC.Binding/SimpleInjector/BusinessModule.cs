using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleInjector;
using IOC.Business.Implementation;
using IOC.FW.Abstraction.Binding;
using IOC.Implementation.Model;
using IOC.Abstraction.Business;

namespace IOC.Binding.SimpleInjector
{
    public class BusinessModule
        : IModule
    {
        public void SetBinding(Container container)
        {
            container.Register<AbstractPersonBusiness, PersonBusiness>(Lifestyle.Singleton);
            //container.Register<IOcupationBusiness, OcupationBusiness>(Lifestyle.Singleton);
        }
    }
}
