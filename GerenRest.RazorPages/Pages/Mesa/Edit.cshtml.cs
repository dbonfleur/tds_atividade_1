using GerenRest.RazorPages.Data;
using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenRest.RazorPages.Pages.Mesa
{
    public class Edit : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public MesaModel MesaModel { get; set; } = new();
        public Edit(AppDbContext context)
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
            if(!ModelState.IsValid)
                return Page();

            var mesaToUpdate = await _context.MesaModel!.FindAsync(id);

            if(mesaToUpdate == null) {
                return NotFound();
            }

            mesaToUpdate.Numero = MesaModel.Numero;
            mesaToUpdate.Ocupada = MesaModel.Ocupada;
            mesaToUpdate.HoraAbertura = MesaModel.HoraAbertura;

            try {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Events/Index");
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}