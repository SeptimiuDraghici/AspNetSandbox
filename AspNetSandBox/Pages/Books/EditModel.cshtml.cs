using System.Linq;
using System.Threading.Tasks;
using AspNetSandBox.Hubs;
using AspNetSandBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandBox.Pages.Shared
{
    /// <summary>Provides the ability to edit book data.</summary>
    public class EditModel : PageModel
    {
        private readonly AspNetSandBox.Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;

        public EditModel(AspNetSandBox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this.context.Attach(Book).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            await hubContext.Clients.All.SendAsync("BookEdited", Book);
            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return this.context.Book.Any(e => e.Id == id);
        }
    }
}
