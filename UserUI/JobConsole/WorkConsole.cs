using Json.Data;
using Json.Database;
using Json.Database.Entity;
using Json.Service.DownloadExchangeJson;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Json.Service.JobConsole
{
    internal class WorkConsole
    {

        private ConsoleAppDatabase _db;
        private DatabaseRefresher _workDB;
        private CRUD _CRUD;
        private Print _print;
        internal WorkConsole(ConsoleAppDatabase db, DatabaseRefresher workDB, CRUD crud, Print print)
        {
            _db = db;
            _workDB = workDB;
            _CRUD = crud;
            _print = print;
        }
        

        public void Run()
        {
            bool isOpen = true;
            

            while (isOpen) 
            {

                //Console.SetCursorPosition(10, 35);

                //_print.Books();
                //Console.WriteLine("");
                //_print.Authors();

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Библиотека");
                Console.WriteLine("\n1 - добавить книгу.\n2 - изменить книгу.\n3 - удалить книгу.\n4 - каталог.\n5 - выход.\n");
                Console.Write("Введите команду: ");


                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:            
                        Console.WriteLine("Добавление книги\n");
                        var addBook = GetData();
                        var addPreface = GetPreface();
                        _CRUD.Create(addBook, addPreface);
                        Console.WriteLine("Книга успешно добавлена");
                        break;
                    case 2:
                        Console.WriteLine("Какую книгу вы хотите изменить? \n");
                        int recordBook = Convert.ToInt32(Console.ReadLine());
                        var insertBook = GetData();
                        var insertPreface = GetPreface();
                        _CRUD.Update(insertBook, recordBook, insertPreface);
                        Console.WriteLine("Книга успешно изменена");
                        break;
                    case 3:
                        Console.WriteLine("Какую книгу вы хотите удалить? ");
                        int record = Convert.ToInt32(Console.ReadLine());
                        if (_db.books.Count() <= record || record < 0)
                        {
                            Console.WriteLine("Такой книги нет");
                            break;
                        }
                        var crud = _CRUD.Delete(record);
                        if (crud == null)
                        {
                            Console.WriteLine("Ошибка с удалением книги");
                        }
                        else { Console.WriteLine($"Книга \"{crud.Title}\" удалена"); }
                        break;
                    case 4:
                        bool isWork = true;
                        int filter = 0;
                        while (isWork)
                        {
                            if (filter == 0)
                            {
                                _print.Catalog();
                            }
                            
                            Console.WriteLine($"Отфильтровать по какому полю?\n" +
                                $"1 - По имени автора\n" +
                                $"2 - По наименованию книги\n" +
                                $"3 - По предисловию\n" +
                                $"4 - По всем\n");
                            filter = Convert.ToInt32(Console.ReadLine());
                            if (filter <= 3 && filter < 0)
                            {
                                isWork = false;
                                break;
                            }
                            
                            Console.WriteLine($"Наименование по фильтрации");
                            string name = Console.ReadLine();
                            if(name == null)
                            {
                                break;
                            }
                            Filter(filter, name);


                        }
                        
                       
                        break;
                    case 5:
                        isOpen = false;
                        break;
                    default: Console.WriteLine("Нет такой команды"); break;
                }

                Console.ReadKey();
                Console.Clear();
            }
            

        }


        public List<Book> GetData()
        {
            var books = new List<Book>() { };

            Console.Write("Название книги: ");
            string? title = Console.ReadLine();
            Console.Write("Категория книги: ");
            string? category = Console.ReadLine();
            Console.Write("Описание: ");
            string? description = Console.ReadLine();
            Console.Write("Стоимость: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Выберите автора: ");
            int authorID = Convert.ToInt32(Console.ReadLine());
            var HasAuthor = _db.authors.FirstOrDefault(x => x.Id == authorID);
            var HasBookAuthor = _db.books.Where(n => n.Title == title).FirstOrDefault(x => x.Id == authorID);
            if (HasBookAuthor != null)
            {
                Console.WriteLine("Такая книга уже существует");
                return books;
            }
            if (HasAuthor == null)
            {
                Console.WriteLine("Такого автора нет");
                return books;
            }


            books.Add(new Book() { Title = title, Category = category, Description = description, Price = price, AuthorID = authorID });
            return books;
        }

        public Library GetPreface()
        {
            var libralis = new Library();
            Console.Write("Предисловие автора: ");
            string? preface = Console.ReadLine();
            libralis.Preface = preface;

            return libralis;
        }


        
        public void Filter(int get, string name)
        {
          
            switch (get)
            {
                
                case 1:
                    var library = _db.libraries
                        .Include(book => book.Book)
                        .Include(author => author.Author)
                        .ToList()
                        .Where(x => x.Author?.Name == name);
                    foreach (var lib in library)
                    {
                        Console.WriteLine($"Автор: {lib.Author?.Name}\n Книга: {lib.Book?.Title}\n Стоимость: {lib.Book?.Price}\n Предисловие: {lib.Preface}\n\n");
                    }
                    break;
                case 2:
                    library = _db.libraries
                        .Include(book => book.Book)
                        .Include(author => author.Author)
                        .ToList()
                        .Where(x => x.Book?.Title == name);
                    foreach (var lib in library)
                    {
                        Console.WriteLine($"Автор: {lib.Author?.Name}\n Книга: {lib.Book?.Title}\n Стоимость: {lib.Book?.Price}\n Предисловие: {lib.Preface}\n\n");
                    }
                    break;
                case 3:
                    library = _db.libraries
                        .Include(book => book.Book)
                        .Include(author => author.Author)
                        .ToList()
                        .Where(x => x.Preface == name);
                    foreach (var lib in library)
                    {
                        Console.WriteLine($"Автор: {lib.Author?.Name}\n Книга: {lib.Book?.Title}\n Стоимость: {lib.Book?.Price}\n Предисловие: {lib.Preface}\n\n");
                    }
                    break;
                case 4:
                    library = _db.libraries
                        .Include(book => book.Book)
                        .Include(author => author.Author)
                        .ToList()
                        .Where(x => x.Author!.Name.ToLower().Contains(name.ToLower())   || x.Book.Title.ToLower().Contains(name.ToLower()) || (x.Preface != null && x.Preface.ToLower().Contains(name.ToLower())));
                    foreach (var lib in library)
                    {
                        Console.WriteLine($"Автор: {lib.Author?.Name}\n Книга: {lib.Book?.Title}\n Стоимость: {lib.Book?.Price}\n Предисловие: {lib.Preface}\n\n");
                    }
                    break;
            }
        }
    }
}
