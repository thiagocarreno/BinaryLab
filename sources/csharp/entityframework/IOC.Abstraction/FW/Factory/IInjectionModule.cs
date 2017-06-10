using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC.Interface.FW.Factory
{
    public interface IInjectionModule<T>
        where T : class
    {
        T container { get; set; }
        T GetInjection();
        TImplementation GetImplementation<TImplementation>()
            where TImplementation : class;
    }
}