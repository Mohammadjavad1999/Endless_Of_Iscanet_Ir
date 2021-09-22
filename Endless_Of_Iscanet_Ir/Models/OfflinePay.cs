using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class OfflinePay
    {
        public OfflinePay()
        {


        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfflinePayId { get; set; }
        [Required]
        [Display(Name = "نام ونام خانوادگی")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "نام پدر")]
        public string Fathersname { get; set; }
        [Required]
        [Display(Name = "شماره شناسنامه")]
        public string Id { get; set; }
        [Required]
        [Display(Name = "شماره رهگیری پرداخت")]
        public string Pay_Id { get; set; }
        [Required]
        [Display(Name = "محل تولد")]
        public string Born_Place { get; set; }
        [Required]
        [Display(Name = "تاریخ تولد")]
        public string Born_Date { get; set; }
        [Required]
        [Display(Name = "شماره نظام پزشکی")]
        public string Medec_Org_Id { get; set; }
        [Required]
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "کد پستی")]
        public string Postal_Code { get; set; }
        [Required]
        [Display(Name = "تخصص")]
        public List<string> Degree_Of_Educations { get; set; }
        [Required]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "تخصص")]
        public string Expert { get; set; }
        [Required]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "شماره تلفن ثابت")]
        public string StaticPhone { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

    }
}