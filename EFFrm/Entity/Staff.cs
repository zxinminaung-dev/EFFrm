using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFFrm.Entity
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string NRC { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartemntId")]
        public virtual Department Department{ get; set; }
    }
}
