using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Models
{
    public class Congress
    {
        public Congress()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int CongressId { get; set; }
        public string CongressTitle { get; set; }

        public string Congress_Description { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual int CommentId { get; set; }


    }
}