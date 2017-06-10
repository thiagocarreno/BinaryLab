using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC.FW.Abstraction.Model
{
    public interface IBaseModel
    {
        DateTime Created { get; set; }
        DateTime? Updated { get; set; }
        Boolean Activated { get; set; }
    }
}
