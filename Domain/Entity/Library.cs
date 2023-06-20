using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Database.Entity;

public class Library
{

    public int Id { get; set; }
    public int AuthorID { get; set; }
    public Author? Author { get; set; }
    public int BookID { get; set; }
    public Book? Book { get; set; }
    public string? Preface { get; set; }


}
