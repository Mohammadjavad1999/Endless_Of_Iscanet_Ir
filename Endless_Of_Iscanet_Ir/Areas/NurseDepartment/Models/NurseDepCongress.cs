using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class NurseDepCongress
    {
        public NurseDepCongress()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int NurseDepCongressId { get; set; }
        [Required]
        public string Congress_Name { get; set; }
        public string Congress_Description { get; set; }
        [Required]
        public string Congress_Abstract { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        [DataType(DataType.ImageUrl)]
        public string FileName { get; set; }

    }
}