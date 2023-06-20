using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Database.Entity;

public class HistoryFiles
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? import { get; set; }
}
