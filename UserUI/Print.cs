using Json.Data;
using Json.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Service;

public class Print
{
    private ConsoleAppDatabase _db;
    internal Print(ConsoleAppDatabase db)
    {
        _db = db;
    }

    public void Books()
    {
        Console.WriteLine("\n*Библиотека*");
        var books = _db.books
                .Include(book => book.Author)
                .ToList();

        Console.WriteLine("\nК А Т А Л О Г");
        foreach (var book in books)
        {
            Console.WriteLine($"ID - {book.Id1C}) \"{book.Title}\"");
        }
    }

    public void Authors()
    {
        Console.WriteLine("*Авторы*");
        var authors = _db.authors
                .ToList();

        Console.WriteLine("\nК А Т А Л О Г");
        foreach (var author in authors)
        {
            Console.WriteLine($"ID - {author.Id}) \"{author.Name}\"");
        }
    }

    public void Catalog()
    {
        var library = _db.libraries.Include(book => book.Book).Include(author => author.Author).ToList();

        foreach (var lib  in library)
        {
            Console.WriteLine($"Автор: {lib.Author?.Name}\n Книга: {lib.Book?.Title}\n Стоимость: {lib.Book?.Price}\n Предисловие: {lib.Preface}\n\n");
        }
        
    }



}
