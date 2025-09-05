using CS2SKINAppWeb.Models;
using CS2SKINAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS2SKINAppWeb.Pages;

public class ComprarModel : PageModel
{
    private ISkinsService _service;
    public ComprarModel(ISkinsService skinsService)
    {
        _service = skinsService;
    }
    public Skins SKIN { get; private set; }  
    public IActionResult OnGet(int id)
    {
        SKIN = _service.Obter(id);

        if (SKIN == null)
        {
            return NotFound();
        }
        return Page();
    }
}
