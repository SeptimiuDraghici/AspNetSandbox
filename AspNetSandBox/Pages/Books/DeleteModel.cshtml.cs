using System.Threading.Tasks;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandBox.Pages.Shared
{
    /// <summary>Deletes books.</summary>
    public class DeleteModel : PageModel
    {
        private readonly AspNetSandBox.Data.ApplicationDbContext context;
        private readonly Microsoft.AspNetCore.SignalR.IHubContext<MessageHub> hubContext;

        public DeleteModel(AspNetSandBox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FindAsync(id);

            if (Book != null)
            {
                hubContext.Clients.All.SendAsync("BookDeleted", Book);
                this.context.Book.Remove(Book);
                await this.context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
