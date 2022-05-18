using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MysqlProba.Data;
using MysqlProba.Model;

namespace MysqlProba.Pages.Crud
{
    public class EditModel : PageModel
    {
        private readonly MysqlProba.Data.MySqlDataContext _context;

        public EditModel(MysqlProba.Data.MySqlDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Diak Diak { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Diakok == null)
            {
                return NotFound();
            }

            var diak =  await _context.Diakok.FirstOrDefaultAsync(m => m.Id == id);
            if (diak == null)
            {
                return NotFound();
            }
            Diak = diak;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Diak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiakExists(Diak.Id))
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

        private bool DiakExists(int id)
        {
          return (_context.Diakok?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
