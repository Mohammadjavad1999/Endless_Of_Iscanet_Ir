using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class UserDetail
    {
        public UserDetail()
        {

        }
        [Key]
        public int UserDetailId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleSenderId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName  { get; set; }
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public string Bio { get; set; }

    }
}