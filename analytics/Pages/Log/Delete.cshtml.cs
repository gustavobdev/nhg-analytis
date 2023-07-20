using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Analytics.Portal.Data.Context;
using Analytics.Portal.Data.Models;

namespace analytics.Pages.Log
{
    public class DeleteModel : PageModel
    {
        private readonly Analytics.Portal.Data.Context.DataContext _context;

        public DeleteModel(Analytics.Portal.Data.Context.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LogModel LogModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Log == null)
            {
                return NotFound();
            }

            var logmodel = await _context.Log.FirstOrDefaultAsync(m => m.Id == id);

            if (logmodel == null)
            {
                return NotFound();
            }
            else 
            {
                LogModel = logmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Log == null)
            {
                return NotFound();
            }
            var logmodel = await _context.Log.FindAsync(id);

            if (logmodel != null)
            {
                LogModel = logmodel;
                _context.Log.Remove(LogModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
