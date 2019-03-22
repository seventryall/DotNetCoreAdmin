using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Web.Models
{
    public class TreeNodeModel
    {
        public string id { get; set; }

        public string label { get; set; }

        public List<TreeNodeModel> children { get; set; }

        public bool isChecked { get; set; }

        public bool disabled { get; set; }

        public bool isLeaf { get; set; }
    }
}
