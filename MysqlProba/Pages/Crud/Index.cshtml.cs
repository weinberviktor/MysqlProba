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
    public class IndexModel : PageModel
    {
        private readonly MysqlProba.Data.MySqlDataContext _context;

        public IndexModel(MysqlProba.Data.MySqlDataContext context)
        {
            _context = context;
        }

        public IList<Diak> Diak { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Diakok != null)
            {
                Diak = await _context.Diakok.ToListAsync();
            }
        }
    }
}
