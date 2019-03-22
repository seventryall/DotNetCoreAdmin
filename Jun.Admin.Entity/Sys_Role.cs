using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Entity
{
    public class Sys_Role:BaseEntity
    {
      

        public string Name { get; set; }

        public string Code { get; set; }

        public string Remark { get; set; }

    }
}
