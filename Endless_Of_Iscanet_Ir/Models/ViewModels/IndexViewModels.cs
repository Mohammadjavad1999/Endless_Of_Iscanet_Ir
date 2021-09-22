using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Models.ViewModels
{
    public class IndexViewModels
    {
        public List<LastNews> LastNews { get; set; }
        public List<Event> Events { get; set; }
        public List<Article> Articles { get; set; }

    }
}