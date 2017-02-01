using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleInjector;
using IOC.DAO.Implementation;
using IOC.Abstraction.DAO;
using IOC.FW.Abstraction.Binding;

namespace IOC.Binding.SimpleInjector
{
    public class DAOModule
        : IModule
    {
        public void SetBinding(Container container)
        {
            container.Register<AbstractPersonDAO, PersonDAO>();
            //container.Register<IOcupationDAO, OcupationDAO>();
        }
    }
}
