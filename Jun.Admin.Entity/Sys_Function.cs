using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Entity
{
    public class Sys_Function:BaseEntity
    {

        public string Name { get; set; }

        public string Code { get; set; }

        public int? Number { get; set; }

    }
}
