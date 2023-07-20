using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Analytics.Portal.Data.Context;
using Analytics.Portal.Data.Models;

namespace analytics.Pages.Log
{
    public class EditModel : PageModel
    {
        private readonly Analytics.Portal.Data.Context.DataContext _context;

        public EditModel(Analytics.Portal.Data.Context.DataContext context)
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

            var logmodel =  await _context.Log.FirstOrDefaultAsync(m => m.Id == id);
            if (logmodel == null)
            {
                return NotFound();
            }
            LogModel = logmodel;
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

            _context.Attach(LogModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogModelExists(LogModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LogModelExists(long? id)
        {
          return (_context.Log?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
