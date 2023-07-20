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
    public class IndexModel : PageModel
    {
        private readonly Analytics.Portal.Data.Context.DataContext _context;

        public IndexModel(Analytics.Portal.Data.Context.DataContext context)
        {
            _context = context;
        }

        public List<LogModel> LogModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
           
        }
    }
}
