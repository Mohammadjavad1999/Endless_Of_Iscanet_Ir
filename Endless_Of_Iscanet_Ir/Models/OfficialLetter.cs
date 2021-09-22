using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class OfficialLetter
    {
        public OfficialLetter()
        {

        }
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
    }
}