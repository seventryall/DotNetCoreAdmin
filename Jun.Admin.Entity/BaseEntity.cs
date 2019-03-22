using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jun.Admin.Entity
{
    public class BaseEntity
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string ID { get; set; }

        public bool? IsDelete { get; set; }

        [MaxLength(50)]
        public string CreateID { get; set; }

        public DateTime? CreateTime { get; set; }

        [MaxLength(50)]
        public string UpdateID { get; set; }

        public DateTime? UpdateTime { get; set; }


    }
}
