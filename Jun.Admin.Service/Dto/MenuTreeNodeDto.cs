using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Service.Dto
{
    public class MenuTreeNodeDto
    {
        public string id { get; set; }

        public string label { get; set; }

        public List<MenuTreeNodeDto> children { get; set; }

        public bool @checked { get; set; }

        public bool disabled { get; set; }

        public bool isLeaf { get; set; }

        public int Number { get; set; }

        public string url { get; set; }
    }
}
