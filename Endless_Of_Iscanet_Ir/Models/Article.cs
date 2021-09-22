using Endless_Of_Iscanet_Ir.Infrastructrues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Endless_Of_Iscanet_Ir.App_LocalResources;


namespace Models
{
    public class Article
    {
        public Article()
        {
         

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }
     //   [Display(ResourceType = typeof(EntityResources), Name = "Article_Writer")]
        [Required]
        public string Article_writer { get; set; }
     //  [Display(ResourceType = typeof(EntityResources), Name = "Title")]
        [Required]
        public string Article_Title { get; set; }
     //   [Display(ResourceType = typeof(EntityResources), Name = "Article_Des")]
        public string Article_Des { get; set; }
//[Display(Name = "Date",ResourceType = typeof(EntityResources), )]
        //[Display(Name = "تاریخ انتشار")]
        //public Nullable<DateTime> Article_Date { get; set; }
   //     [Display(Name = "Abstract_Description" ,ResourceType =typeof(EntityResources))]
        [Required]
        public string Abstract_Description { get; set; }
   //       [Display(ResourceType = typeof(EntityResources), Name = "FileName")]
      //  [Display(Name = "")]
        public string Article_file_Name { get; set; }
        /// <summary>
        /// It`s May Be Require
        /// </summary>
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public List<Comment> Comments { get; set; }
        //public virtual int CommentId { get; set; }
        public virtual List<DocumentionGallery> UploadGalleries { get; set; }
        public virtual int DocumentId { get; set; }
        public int IndexItemId { get; set; }




    }
}