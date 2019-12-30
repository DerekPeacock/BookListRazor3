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
        private readonly BooksDbContext _context;

        public IndexModel(BooksDbContext context)
        {
            _context = context;
        }

        public IList<Book> Books { get;set; }

        public async Task OnGetAsync()
        {
            Books = await _context.Books.ToListAsync();
        }
    }
}
