using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandBox.Pages.Shared
{
    /// <summary>Model for main dashboard of books.</summary>
    public class IndexModel : PageModel
    {
        private readonly AspNetSandBox.Data.ApplicationDbContext context;

        public IndexModel(AspNetSandBox.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await this.context.Book.ToListAsync();
        }
    }
}
