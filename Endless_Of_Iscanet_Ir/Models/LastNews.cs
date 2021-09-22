using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
//using App_LocalResources;


namespace Models
{
    public class LastNews
    {
        public LastNews()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int LastNewsId { get; set; }
    //     [Display(Name = "News_Writer", ResourceType = typeof(EntityResources))]
     

        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessageResources), ErrorMessageResourceName = "Required")]

        public string News_Writer { get; set; }
     //    [Display(Name = "Title",ResourceType = typeof(EntityResources))]   
        [Required]
        public string LastNews_Title { get; set; }
        //  [Display(Name = "Description",ResourceType = typeof(EntityResources))]
        [Display(Name = "توضیحات خبر")]
        [Required]
        public string LastNews_Des { get; set; }
        // [Display(Name = "Date",ResourceType = typeof(EntityResources) )]
        [Display(Name = "تاریخ خبر")]
        public DateTime LastNews_Date { get; set; }
        //   [Display(Name = "Abstract_Description",ResourceType = typeof(EntityResources))]
        [Display(Name = "چکیده مطالب")]
        [Required]
        public string Abstract_Description { get; set; }
        // [Display(Name = "FileName",ResourceType = typeof(EntityResources))]
        public string FileName { get; set; }
        public virtual int CommentId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CommentsVM> CommentViewModels { get; set; }
        public virtual List<DocumentionGallery> UploadGalleries { get; set; }


    }
}