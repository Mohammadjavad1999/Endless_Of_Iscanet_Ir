using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class AdminViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public string Message { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAdresses { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageCounter { get; set; }
        public string Message_Title { get; set; }
        public bool userAccept { get; set; }

    }
}