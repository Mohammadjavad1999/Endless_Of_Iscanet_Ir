using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{

    public class PostViewModel
    {
        [Key]
        public int PostID { get; set; }
        public string Message { get; set; }
        public string Abstract_Description { get; set; }
        public DateTime Date { get; set; }


    }
    public class CommentsVM
    {
        [Key]
        public int ComID { get; set; }
        public string CommentMsg { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual int EventId { get; set; }
        public virtual Event Events { get; set; }
        public virtual int LastNewsId { get; set; }
        public virtual LastNews LastNews { get; set; }



    }
    public class ReplyVM
    {
        [Key]
        public int ReplyID { get; set; }
        public string CommentMsg { get; set; }
        public DateTime CommentDate { get; set; }
        public CommentsVM Comment { get; set; }


    }


}