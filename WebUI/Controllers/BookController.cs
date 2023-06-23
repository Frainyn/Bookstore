using Application.Service;
using Json.Data;
using Json.Database.Entity;
using Json.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Controllers
{
    
    public class BookController : BaseController
    {
        private readonly CRUD _crud;
        private readonly ConsoleAppDatabase _db;
        private readonly DownloadExch _exch;
   

        public BookController(CRUD crud, ConsoleAppDatabase db, DownloadExch exch)
        {
            _crud = crud;
            _db = db;
            _exch = exch;

        }


        
        [HttpGet("GetFullBook")]
        public async Task<ActionResult<List<Book>>> GetBook()
        {
            return Ok(_db.books);
        }


        [HttpGet("{id}")]
        public IActionResult GetBook([FromRoute] int id)
        {
            var books = _db.books.Where(x => x.Id1C == id);
            return Ok(books);

        }


        //Добавить книгу
        [HttpPost("AddBook")]
        public void CreateBook(string title, string category, string description, decimal price, int authorID, string preface)
        {
            var book = new List<Book>();
            var libralis = new Library();
            book.Add(new Book() { Title = title, Category = category, Description = description, Price = price, AuthorID = authorID });
            libralis.Preface = preface;
            _crud.Create(book, libralis);
        }

        //Добавить книгу
        //[HttpPost]
        //public void CreateBook([FromBody]Book book)
        //{
        //    _crud.Create(book);
        //}

        [HttpPost]
        public ActionResult CreateBook([FromBody] Book book)
        {
            var addBook = _crud.Create(book);
            return Ok(addBook);
        }

        //[HttpPost("{full}")]
        //public JsonResult CreateBook([FromQuery][BindRequired] Book book)
        //{
        //    var price = book.Price; 
        //    if (price == null) {
        //        return new JsonResult(Ok("sdf"));
        //    }
        //    //_crud.Create(book, library);
        //    return new JsonResult(Ok(book));
        //}






        [HttpPut("{id}")]
        public ActionResult InsertBook([FromRoute] int id, string title, string category, string description, decimal price, int authorID, string preface)
        {
            var book = new List<Book>();
            var libralis = new Library();
            book.Add(new Book() { Title = title, Category = category, Description = description, Price = price, AuthorID = authorID });
            libralis.Preface = preface;
            var res = _crud.Update(book, id, libralis);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            var book = _crud.Delete(id);
            _db.books.Remove(book);
            _db.SaveChanges();
            return Ok(book);






            //if (process != null)
            //    return Ok();

            //return BadRequest();

        }

        [HttpPut]
        public void Update()
        {
            _exch.Update();
            

        }

    }
}
