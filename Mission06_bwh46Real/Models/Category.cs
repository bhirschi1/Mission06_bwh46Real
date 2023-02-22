using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_bwh46Real.Models
{
    // This is a class of categories, there will be an id and a name for each
    public class Category
    {
        [Key]
        [Required]
        public int categoryId { get; set; }
        public string catName { get; set; }
    }
}
