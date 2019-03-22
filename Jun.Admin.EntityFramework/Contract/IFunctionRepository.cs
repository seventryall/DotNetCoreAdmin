using Jun.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.EntityFramework.Contract
{
    public interface IFunctionRepository
    {
        IEnumerable<Sys_Function> GetAllFunction();
    }
}
