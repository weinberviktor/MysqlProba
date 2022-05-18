using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MysqlProba.Data;
using MysqlProba.Model;

namespace MysqlProba.Pages.Crud
{
    public class CreateModel : PageModel
    {
        private readonly MysqlProba.Data.MySqlDataContext _context;

        public CreateModel(MysqlProba.Data.MySqlDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Diak Diak { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Diakok == null || Diak == null)
            {
                return Page();
            }

            _context.Diakok.Add(Diak);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
