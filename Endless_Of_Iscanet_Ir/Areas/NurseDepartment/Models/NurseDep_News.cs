using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class NurseDep_News
    {
        public NurseDep_News()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int NurseDep_NewsId { get; set; }
        [Required]
        public string News_Title { get; set; }
        [Required]
        public string News_Abstract { get; set; }
        public string News_Author { get; set; }
        public string News_Description { get; set; }
        [DataType(DataType.ImageUrl)]
        public string FileName { get; set; }
        public DateTime Date { get; set; }

    }
}