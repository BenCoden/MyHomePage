using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyHomePage.EntityFrameworkCoreSQL;
using MyHomePage.EntityFrameworkCoreSQL.Models;

namespace MyHomePage
{
    public class EditModel : PageModel
    {
        private readonly MyHomePage.EntityFrameworkCoreSQL.AppDbContext _context;

        public EditModel(MyHomePage.EntityFrameworkCoreSQL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Links).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinksExists(Links.Id))
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

        private bool LinksExists(int id)
        {
            return _context.Links.Any(e => e.Id == id);
        }
    }
}
