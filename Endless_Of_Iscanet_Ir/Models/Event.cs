using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Models
{
    public class Event
    {
        public Event()
        {
            this.Comments = new HashSet<Comment>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        [Display(Name = "نویسنده متن رویداد")]
        public string Event_Writer { get; set; }
        [Display(Name = "تیتر رویداد")]
        [Required]
        public string Event_Title { get; set; }
        [Display(Name = "توضیحات در مورد رویداد")]
        [Required]
        public string Event_Des { get; set; }
        [Display(Name = "تاریخ رویداد")]
        public DateTime Event_Date { get; set; }
        [Display(Name = "چکیده مطالب")]
     //   [StringLength(maximumLength: 140, MinimumLength = 0)]
        [Required]
        public string Abstract_Description { get; set; }
        public string FileName { get; set; }
        public virtual int CommentId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CommentsVM>  CommentViewModels { get; set; }

        public virtual List<DocumentionGallery> UploadGalleries { get; set; }


    }
}