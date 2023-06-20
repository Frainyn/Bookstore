using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Database.Entity;

public class Book
{

    public int Id { get; set; }
    public int Id1C { get; set; }
    public string? Category { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int AuthorID { get; set; }
    public Author? Author { get; set; }
    public List<Library>? Libraries { get; set; }



}
