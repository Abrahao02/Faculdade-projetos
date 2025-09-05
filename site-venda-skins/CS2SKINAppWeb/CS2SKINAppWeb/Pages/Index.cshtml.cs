using CS2SKINAppWeb.Models;
using CS2SKINAppWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS2SKINAppWeb.Pages;

public class IndexModel : PageModel
{
    private ISkinsService _service;

    
    public IndexModel(ISkinsService skinsService)
    {
        _service = skinsService;
    }
    public IList<Skins> ListaSkins { get; private set; }

    public void OnGet()
    {
        ListaSkins = _service.ObterTodos();
    }
}