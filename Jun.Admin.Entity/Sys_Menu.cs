using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Entity
{
    public class Sys_Menu:BaseEntity
    {
        public  string Name { get; set; }

        public string Url { get; set; }

        public string ParentID { get; set; }

        public int? Number { get; set; }

        public string Icon { get; set; }

        public bool? IsParent { get; set; }

        public string Remark { get; set; }
       
    }
}
