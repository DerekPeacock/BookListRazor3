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
    }
}