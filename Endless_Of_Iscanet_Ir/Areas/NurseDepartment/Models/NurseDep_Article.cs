using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class NurseDep_Article
    {
        public NurseDep_Article()
        {

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }

    }
}