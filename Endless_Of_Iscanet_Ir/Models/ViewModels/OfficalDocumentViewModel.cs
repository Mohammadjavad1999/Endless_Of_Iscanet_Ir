using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.ViewModels
{
    public class OfficalDocumentViewModel
    {
        public  OfficalDocumentViewModel ()
        { }
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime? Date { get; set; }

    }
}