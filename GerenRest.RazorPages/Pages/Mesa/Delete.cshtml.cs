using GerenRest.RazorPages.Data;
using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenRest.RazorPages.Pages.Mesa
{
    public class Delete : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public MesaModel MesaModel { get; set; } = new();
        public Delete(AppDbContext context)
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
    
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var eventToDelete = await _context.MesaModel!.FindAsync(id);

            if(eventToDelete == null) {
                return NotFound();
            }

            try {
                _context.MesaModel.Remove(eventToDelete);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Mesa/Index");
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}