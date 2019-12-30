using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookListRazor.Web.Models;

namespace BookListRazor.Web.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookListRazor.Web.Models.BooksDbContext _context;

        public IndexModel(BookListRazor.Web.Models.BooksDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
