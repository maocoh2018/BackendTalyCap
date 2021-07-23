using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Libros
    {
        public int idBook { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string pageCount { get; set; }
        public string excerpt { get; set; }
        public DateTime publishDate { get; set; }
        public string autor { get; set; }
    }
}

