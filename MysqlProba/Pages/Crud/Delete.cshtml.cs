using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MysqlProba.Data;
using MysqlProba.Model;

namespace MysqlProba.Pages.Crud
{
    public class DeleteModel : PageModel
    {
        private readonly MysqlProba.Data.MySqlDataContext _context;

        public DeleteModel(MysqlProba.Data.MySqlDataContext context)
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

            var diak = await _context.Diakok.FirstOrDefaultAsync(m => m.Id == id);

            if (diak == null)
            {
                return NotFound();
            }
            else 
            {
                Diak = diak;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Diakok == null)
            {
                return NotFound();
            }
            var diak = await _context.Diakok.FindAsync(id);

            if (diak != null)
            {
                Diak = diak;
                _context.Diakok.Remove(Diak);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
