using GerenRest.RazorPages.Data;
using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenRest.RazorPages.Pages.Mesa
{
    public class Details : PageModel
    {
        private readonly AppDbContext _context;
        public MesaModel MesaModel { get; set; } = new();
        public Details(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null || _context.MesaModel == null) {
                return NotFound();
            }

            var MesaModel = await _context.MesaModel.FirstOrDefaultAsync(e => e.MesaID == id);

            if(MesaModel == null) {
                return NotFound();
            }

            this.MesaModel = MesaModel;

            return Page();
        }
    }
}