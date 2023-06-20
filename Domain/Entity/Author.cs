using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Database.Entity;

public class Author
{
    public int Id { get; set; }
    public string? Name { get; set; }



    public List<Library>? Libraries { get; set; }
}
