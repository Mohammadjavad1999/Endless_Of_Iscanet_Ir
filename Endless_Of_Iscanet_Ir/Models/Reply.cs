using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class Reply
    {
        public Reply() { }
        public int Id { get; set; }
        public string CommentMsg { get; set; }
        public string User { get; set; }
        public DateTime CommentedDate { get; set; }
        public virtual int CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comments { get; set; }
    }
}