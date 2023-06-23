using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class NotFoundAuthorException : Exception
{

    public int AuthorID { get; set; } 

    public NotFoundAuthorException(string message, int authorID) : base(message) 
    {
        AuthorID = authorID;
    }

    


}
