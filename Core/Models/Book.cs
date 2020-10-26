using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="bu alan zorunludur")]
        public string Name { get; set; }
        [Required(ErrorMessage = "bu alan zorunludur")]
        public string WriterName { get; set; }
        [Required(ErrorMessage = "bu alan zorunludur")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
