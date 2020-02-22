using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scripture_Journal.Data;
using Scripture_Journal.Models;

namespace Scripture_Journal
{
    public class CreateModel : PageModel
    {
        private readonly Scripture_Journal.Data.Scripture_JournalContext _context;

        public CreateModel(Scripture_Journal.Data.Scripture_JournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entry Entry { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Entry.Add(Entry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
