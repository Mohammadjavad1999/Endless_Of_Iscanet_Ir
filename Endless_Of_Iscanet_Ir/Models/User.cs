using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class User
    {
        public User()
        {

        }
        [Key]
        public int Id { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageProfile { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Expert { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public int MedeicialIdentifeir { get; set; }
        public string Identifeir { get; set; }


    }
}