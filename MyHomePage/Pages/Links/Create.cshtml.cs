using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyHomePage.EntityFrameworkCoreSQL;
using MyHomePage.EntityFrameworkCoreSQL.Models;

namespace MyHomePage
{
    public class CreateModel : PageModel
    {
        private readonly MyHomePage.EntityFrameworkCoreSQL.AppDbContext _context;

        public CreateModel(MyHomePage.EntityFrameworkCoreSQL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Links Links { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Links.Add(Links);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
