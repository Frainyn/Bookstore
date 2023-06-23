using Domain.Exceptions;
using Json.Data;
using Json.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Service;

public class CRUD
{
    private ConsoleAppDatabase _db;

    public CRUD(ConsoleAppDatabase db)
    {
        _db = db;
    }

    public void Create(List<Book> DataBook, Library DataLibrary)
    {
        var Data = DataBook[0];
        var books = _db.books;
        int c = books.Max(x => x.Id1C);
        var id1C = c + 1;
        Book book = new Book
        {
            Id1C = id1C,
            Title = Data.Title,
            Category = Data.Category,
            Description = Data.Description,
            Price = Data.Price,
            AuthorID = Data.AuthorID
        };

        _db.books.Add(book);
        _db.SaveChanges();

        

        
        var res = _db.libraries.FirstOrDefault(x => x.BookID == book.Id1C);
        if (res == null)
        {
            var library = new Library()
            {
                BookID = book.Id1C,
                AuthorID = book.AuthorID,
                Preface = DataLibrary.Preface
            };
            _db.libraries.Add(library);
            _db.SaveChanges();
        }
        
        
        


    }


    public Book Create(Book DataBook)
    {
        var Data = DataBook;
        var books = _db.books;
        int c = books.Max(x => x.Id1C);
        var id1C = c + 1;

       

        if (_db.authors.FirstOrDefault(x=>x.Id== Data.AuthorID) == null)
        {
            
            throw new NotFoundAuthorException("Not Found", Data.AuthorID);
        }
        

        Book book = new Book
        {
            Id1C = id1C,
            Title = Data.Title,
            Category = Data.Category,
            Description = Data.Description,
            Price = Data.Price,
            AuthorID = Data.AuthorID
        };

        _db.books.Add(book);
        _db.SaveChanges();

        return book;
        





    }

    public Book Update(List<Book> DataBook, int recordBook, Library DataLibrary) 
    {
        var Data = DataBook[0];
        var record = _db.books.FirstOrDefault(x => x.Id1C == recordBook);
        if (record == null)
        {
            throw new Exception("not record");
        }

        record.Title = Data.Title;
        record.Category = Data.Category;
        record.Description = Data.Description;
        record.Price = Data.Price;
        record.AuthorID = Data.AuthorID;
        _db.SaveChanges();

        var library = _db.libraries.FirstOrDefault(x => x.BookID == recordBook);
        if (library == null)
        {
            throw new Exception("not library");
        }

        library.Preface = DataLibrary.Preface;

        return record;
    }

    public Book Delete(int record) 
    {
        
        Book? book = _db.books
            .Where(x => x.Id1C == record)
            .FirstOrDefault();


        _db.books.Remove(book);
        _db.SaveChanges();
        return book;

    }
}
