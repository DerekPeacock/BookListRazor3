using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Web.Contollers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BooksDbContext _db;

        public BooksController(BooksDbContext db)
        {
            _db = db; 
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Books.ToList() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var book = _db.Books.FirstOrDefault(u => u.Id == id);

            if(book == null)
            {
                return Json(new { success = false, message = "Error Deleting!" });
            }

            _db.Books.Remove(book);
            _db.SaveChanges();

            return Json(new { success = true, message = "Delete Completed!" });
        }
    }
}