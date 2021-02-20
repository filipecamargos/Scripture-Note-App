using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Notes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }

        public async Task OnGetAsync()
        {
            var scriptures = from m in _context.Scripture
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.ScriptureReference.Contains(SearchString));
            }

            //Search by notes
            if (!string.IsNullOrEmpty(Notes))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(Notes));
            }

            //Filter
            if((Filter == "Book" || Filter == "Date"))
            {
                if(Filter == "Book")
                {
                    // Use LINQ to get a query that get the order by RealeaseDate
                    IQueryable<Scripture> genreQuery = from m in _context.Scripture
                                                       orderby m.ScriptureReference
                                                       select m;
                    scriptures = genreQuery;

                }
                else if (Filter == "Date")
                {
                    // Use LINQ to get a query that get the order by date
                    IQueryable<Scripture> genreQuery = from m in _context.Scripture
                                                       orderby m.ReleaseDate
                                                       select m;
                    scriptures = genreQuery;
                }

            }

            Scripture = await scriptures.ToListAsync();
        }
    }
}
