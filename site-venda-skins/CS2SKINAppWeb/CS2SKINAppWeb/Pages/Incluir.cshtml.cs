using CS2SKINAppWeb.Models;
using CS2SKINAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS2SKINAppWeb.Pages
{
    public class IncluirModel : PageModel
    {
        private ISkinsService _service;
        public IncluirModel(ISkinsService skinsService)
        {
            _service = skinsService;
        }

        [BindProperty]
        public Skins SKIN { get; set; }
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Incluir(SKIN);

            return RedirectToPage("/Index");
        }
    }
}

