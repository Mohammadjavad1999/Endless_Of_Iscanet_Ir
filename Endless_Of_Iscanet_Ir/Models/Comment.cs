using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Models
{
    public class Comment
    {
        public Comment()
        {
            this.Replies = new HashSet<Reply>();

        }
        public int CommentId { get; set; }
        [Display(Name = "نظرات")]
        public string Comment_writer { get; set; }
        [Display(Name = "متن نظر")]
        public string CommentMsg { get; set; }
        public DateTime CommentedDate { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public virtual int LastNewsId { get; set; }
        public virtual LastNews LastNews { get; set; }
        public virtual int  EventId { get; set; }
        public virtual Event Events { get; set; }
        public virtual int  CongressId { get; set; }
        public virtual Congress Congresses { get; set; }





    }
}