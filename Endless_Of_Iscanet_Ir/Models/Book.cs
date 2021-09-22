using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Resources;


namespace Models
{
    public class Book
    {
        public Book() { }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [Display(Name = "نویسنده کتاب")]
        [Required(ErrorMessage = "لطفا نویسنده را مشخص کنید")]

        public string Book_writer { get; set; }

        [Display(Name = "تیتر کتاب")]

        public string Book_Title { get; set; }
        [Display(Name = "توضیحات کتاب")]

        public string Book_Des { get; set; }

        //[Display(Name = "تاریخ پست")]


      //  public DateTime Book_Date { get; set; }

        [Display(Name = "نام فایل کتاب")]
        public string Book_file_Name { get; set; }

        [Display(Name = "چکیده مطلب")]
        [StringLength(maximumLength: 140, MinimumLength = 0)]
        [Required(ErrorMessage = "لطفا خلاصه ای در مورد کتاب بنویسید")]
        public string Abstract_Description { get; set; }

        /// <summary>
        /// It`s May Be Require
        /// </summary>
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public List<Comment> Comments { get; set; }
        //public virtual int CommentId { get; set; }
        public virtual List<DocumentionGallery> UploadGalleries { get; set; }
        public virtual int DocumentId { get; set; }
    }
}