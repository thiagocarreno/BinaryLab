using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOC.FW.Code;
using IOC.Implementation.Model;
using IOC.Abstraction.DAO;

namespace IOC.Abstraction.Business
{
    public abstract class AbstractPersonBusiness
        : BaseBusiness<Person>
    {
        public AbstractPersonBusiness(AbstractPersonDAO dao)
            : base(dao)
        { }
    }
}