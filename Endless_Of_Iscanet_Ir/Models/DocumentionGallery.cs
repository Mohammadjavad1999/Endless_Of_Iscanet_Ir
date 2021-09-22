using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    public class DocumentionGallery
    {
        public DocumentionGallery() { }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Key]
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public DateTime DocumentDate { get; set; }
        public string DocumentRoute { get; set; }
        public string FileType { get; set; }
                                           //  public HttpPostedFileBase FileDownload { get; set; }

    }
}