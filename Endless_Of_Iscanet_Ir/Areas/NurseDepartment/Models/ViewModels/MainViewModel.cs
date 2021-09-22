using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class MainViewModel
    {
        public MainViewModel()
        {

        }
        [Key]
        public int MainViewModelId { get; set; }
        public virtual List<NurseDep_News> News { get; set; }
        public virtual List<EducationCource> EductionCources { get; set; }
        public virtual List<NurseDepCongress> Congress { get; set; }
    }
}