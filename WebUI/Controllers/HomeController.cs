using Json.Data;
using Json.Database.Entity;
using Json.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly CRUD _crud;
        private readonly ConsoleAppDatabase _db;
        public HomeController(CRUD crud, ConsoleAppDatabase db)
        {
            _crud = crud;
            _db = db;
        }

        
        
           

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBook()
        {
            

            return Ok(_db.books);
        }
        
        
    }
}
