using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductAssignmentEntity.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
    }
}
