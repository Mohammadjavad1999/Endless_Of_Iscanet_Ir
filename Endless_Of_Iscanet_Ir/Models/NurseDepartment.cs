using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using App_LocalResources;
namespace Models
{
    public class NurseDepartment
    {
        public NurseDepartment()
        {
            
        }
        public int Id { get; set; }
     //   [Required(ErrorMessageResourceType =typeof(EntityResources),ErrorMessageResourceName ="Title")]
        public string Title { get; set; }
      //  [Required(ErrorMessageResourceType =typeof(EntityResources),ErrorMessageResourceName ="Description")]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}