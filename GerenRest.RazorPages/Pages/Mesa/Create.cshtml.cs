using GerenRest.RazorPages.Data;
using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenRest.RazorPages.Pages.Mesa
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
        [BindProperty]
        public MesaModel MesaModel { get; set; } = new();
        public Create(AppDbContext context)
        {
            _context = context;
        }
    
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if(!ModelState.IsValid)
                return Page();

            try {
                _context.Add(MesaModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Mesa/Index");
            } catch(DbUpdateException) {
                return Page();
            }
        }
    }
}