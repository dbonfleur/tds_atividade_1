using GerenRest.RazorPages.Data;
using GerenRest.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenRest.RazorPages.Pages.Events
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;
        public List<MesaModel> MesaModels { get; set; } = new();
        public Index(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            MesaModels = await _context.MesaModel!.ToListAsync();
            return Page();
        }
    }
}