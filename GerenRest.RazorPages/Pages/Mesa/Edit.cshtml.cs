using System.Globalization;
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
        public DateTime HoraEdit { get; set; }
        [BindProperty]
        public string? HoraForm { get; set; }
        public Edit(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null || _context.Mesas == null) {
                return NotFound();
            }

            var mesaModel = await _context.Mesas!.FirstOrDefaultAsync(e => e.MesaID == id);

            if(mesaModel == null) {
                return NotFound();
            }
            
            HoraEdit = DateTime.ParseExact(mesaModel.HoraAbertura.ToString()!, "dd/MM/yyyy HH:mm:ss", null);
            HoraForm = HoraEdit.ToShortTimeString();
            MesaModel = mesaModel;

            return Page();
        }
    
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if(!ModelState.IsValid)
                return Page();

            var mesaToUpdate = await _context.Mesas!.FindAsync(id);

            if(mesaToUpdate == null) {
                return NotFound();
            }

            mesaToUpdate.Numero = MesaModel.Numero;
            mesaToUpdate.Ocupada = MesaModel.Ocupada;
            mesaToUpdate.HoraAbertura = MesaModel.HoraAbertura;

            try {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Mesa/Index");
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}