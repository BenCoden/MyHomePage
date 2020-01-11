using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyHomePage.EntityFrameworkCoreSQL;
using MyHomePage.EntityFrameworkCoreSQL.Models;

namespace MyHomePage
{
    public class DetailsModel : PageModel
    {
        private readonly MyHomePage.EntityFrameworkCoreSQL.AppDbContext _context;

        public DetailsModel(MyHomePage.EntityFrameworkCoreSQL.AppDbContext context)
        {
            _context = context;
        }

        public Links Links { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Links = await _context.Links.FirstOrDefaultAsync(m => m.Id == id);

            if (Links == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
