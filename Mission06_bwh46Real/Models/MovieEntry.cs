using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_bwh46.Models
{
    //this class is for the creation of each MovieEntry object. There is an additional layer of data validation (not necessarily needed but it's there)
    // and it also includes a primary key of entryId
    public class MovieEntry
    {
        [Key]
        [Required]
        public int entryId { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }
        public bool edited { get; set; }
        public string lent { get; set; }
        [MaxLength(25)]
        public string notes { get; set; }

    }
}
