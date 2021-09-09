using System.Threading.Tasks;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandBox.Pages.Shared
{
    /// <summary>Shows details about a book.</summary>
    public class DetailsModel : PageModel
    {
        private readonly AspNetSandBox.Data.ApplicationDbContext context;

        public DetailsModel(AspNetSandBox.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
