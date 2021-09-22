using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class CongressRegisterForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "شماره تلفن")]
        //upda  [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "لطفا شماره تلفن خود را وارد کنید")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "لطفا تخصص خود را وارد کنید")]
        [Display(Name = "تخصص")]
        public string Expert { get; set; }
        [Display(Name = "شماره نظام پزشکی")]
        public string Mediecial_Org_Id { get; set; }
        [Display(Name = "تاریخ ثبت نام")]
        public DateTime DateOfRegister { get; set; }
        [Required(ErrorMessage = "لطفا نام و نام خانوادگی خود را وارد کنید")]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }



    }
}