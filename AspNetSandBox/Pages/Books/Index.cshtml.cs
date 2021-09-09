using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetSandBox.Data;
using AspNetSandBox.Models;

namespace AspNetSandBox.Pages.Shared
{
    public class IndexModel : PageModel
    {
        private readonly AspNetSandBox.Data.ApplicationDbContext _context;

        public IndexModel(AspNetSandBox.Data.ApplicationDbContext context)
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
