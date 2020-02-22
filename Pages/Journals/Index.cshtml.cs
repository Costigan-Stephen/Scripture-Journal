using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scripture_Journal.Data;
using Scripture_Journal.Models;

namespace Scripture_Journal
{
    public class IndexModel : PageModel
    {
        private readonly Scripture_Journal.Data.Scripture_JournalContext _context;

        public IndexModel(Scripture_Journal.Data.Scripture_JournalContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; }
        [BindProperty(SupportsGet = true)]
        [Display(Name = "Book")]
        public string SearchBook { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        [BindProperty(SupportsGet = true)]
        [Display(Name = "Notes")]
        public string SearchNote { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            var Journals = from m in _context.Entry
                           select m;

            if (!string.IsNullOrEmpty(SearchBook))
            {
                Journals = Journals.Where(s => s.Book.Contains(SearchBook));
            }
            if (!string.IsNullOrEmpty(SearchNote))
            {
                Journals = Journals.Where(x => x.Notes.Contains(SearchNote));
            }

            //SORTING

            ViewData["BookSortParm"] = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "book_desc":
                    Journals = Journals.OrderByDescending(m => m.Book);
                    break;
                case "Date":
                    Journals = Journals.OrderBy(m => m.DateAdded);
                    break;
                case "date_desc":
                    Journals = Journals.OrderByDescending(m => m.DateAdded);
                    break;
                default:
                    Journals = Journals.OrderBy(m => m.Book);
                    break;
            }

            Entry = await Journals.AsNoTracking().ToListAsync();
        }
    }
}
