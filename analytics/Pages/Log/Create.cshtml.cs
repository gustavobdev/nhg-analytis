using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Analytics.Portal.Data.Context;
using Analytics.Portal.Data.Models;

namespace analytics.Pages.Log
{
    public class CreateModel : PageModel
    {
        private readonly Analytics.Portal.Data.Context.DataContext _context;

        public CreateModel(Analytics.Portal.Data.Context.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LogModel LogModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Log == null || LogModel == null)
            {
                return Page();
            }

            _context.Log.Add(LogModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
