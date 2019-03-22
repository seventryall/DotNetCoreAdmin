using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Entity
{
    public class Sys_Role_Menu_Function:BaseEntity
    {
        public string RoleID { get; set; }

        public string MenuID { get; set; }

        public string FunctionID { get; set; }

      
    }
}
