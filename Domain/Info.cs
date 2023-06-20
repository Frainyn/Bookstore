using Json.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Database
{
    public class Info
    {
        public List<Book>? Books { get; set; }
        public List<Author>? Authors { get; set; }
        public List<Library>? Libraries { get; set; }

        public List<HistoryFiles>? HistoryFiles { get; set; }
    }
}
