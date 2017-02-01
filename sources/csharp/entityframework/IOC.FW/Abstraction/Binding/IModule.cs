using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleInjector;

namespace IOC.FW.Abstraction.Binding
{
    public interface IModule
    {
        void SetBinding(Container container);
    }
}
