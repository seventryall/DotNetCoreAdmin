using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Entity
{
    public class Sys_User_Role:BaseEntity
    {
        public string UserID { get; set; }

        public string RoleID { get; set; }

      
    }
}
