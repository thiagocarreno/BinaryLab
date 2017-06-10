using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOC.FW.Code;
using IOC.Implementation.Model;
using IOC.Abstraction.Business;
using IOC.Abstraction.DAO;

namespace IOC.Business.Implementation
{
    public class PersonBusiness
        : AbstractPersonBusiness
    {
        public PersonBusiness(AbstractPersonDAO dao)
            : base(dao)
        { }
    }
}