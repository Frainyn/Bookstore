using Application.Service;
using Json.Data;
using Json.Database.Entity;
using Json.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CRUD _crud;
        private readonly ConsoleAppDatabase _db;
        private readonly DownloadExch _exch;
   

        public ValuesController(CRUD crud, ConsoleAppDatabase db, DownloadExch exch)
        {
            _crud = crud;
            _db = db;
            _exch = exch;
        }


        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBook()
        {
            return Ok(_db.books);
        }


        [HttpGet("id")]
        public async Task<ActionResult<List<Book>>> GetSingleBook(int id)
        {
            return Ok(_db.books.Where(x => x.Id1C == id));
        }

        [HttpPost]
        public void CreateBook(string title, string category, string description, decimal price, int authorID, string preface)
        {
            var book = new List<Book>();
            var libralis = new Library();
            book.Add(new Book() { Title = title, Category = category, Description = description, Price = price, AuthorID = authorID });
            libralis.Preface = preface;
            _crud.Create(book, libralis);
        }

        [HttpPut("id")]
        public void InsertBook(int id, string title, string category, string description, decimal price, int authorID, string preface)
        {
            var book = new List<Book>();
            var libralis = new Library();
            book.Add(new Book() { Title = title, Category = category, Description = description, Price = price, AuthorID = authorID });
            libralis.Preface = preface;
            _crud.Update(book, id, libralis);
        }

        [HttpDelete("id")]
        public ActionResult DeleteBook(int id)
        {
            var process = _crud.Delete(id);
            if (process != null)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpGet("update")]
        public void Update()
        {
            _exch.Update();
            

        }

    }
}
