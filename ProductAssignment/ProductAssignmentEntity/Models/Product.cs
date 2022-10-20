using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductAssignmentEntity.Models
{
    public enum ChannelId
    {
        Store, 
        Online, 
        All
    }
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        public string ProductName { get; set; }

        public int ProductYear { get; set; }

        [Required]
        public int ChannelId { get; set; } 

        public int SizeScaleId { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreatedBy { get; set; }
        public ICollection<Article> Articles { get; set; }


    }
        
}
