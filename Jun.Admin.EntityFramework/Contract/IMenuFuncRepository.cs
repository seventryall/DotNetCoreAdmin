using Jun.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jun.Admin.EntityFramework.Contract
{
    public interface IMenuFuncRepository
    {
        IEnumerable<Sys_Menu_Function> GetAllMenuFunc();

    }
}
