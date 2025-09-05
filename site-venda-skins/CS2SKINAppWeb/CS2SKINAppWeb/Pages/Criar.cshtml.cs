using CS2SKINAppWeb.Models;
using CS2SKINAppWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace CS2SKINAppWeb.Pages
{
    [Authorize]
    public class CriarModel : PageModel
    {
        private ISkinsService _service;
        private readonly IToastNotification _toastNotification;

        public CriarModel(ISkinsService skinsService, IToastNotification toastNotification)
        {
            _service = skinsService;
            _toastNotification = toastNotification;
        }

        public List<string> OpcoesCondicao { get; } = new List<string>
        {
        "Nova de fábrica",
        "Pouco desgastada",
        "Testado em campo",
        "Bem desgastada",
        "Veterano de guerra",
        };

        [BindProperty]
        public Skins SKIN { get; set; }
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Incluir(SKIN);

            // Exibir uma mensagem de sucesso usando o NToastNotify
            _toastNotification.AddSuccessToastMessage("Operação de inclusão bem-sucedida!");
            return RedirectToPage("/Index");
        }
    }
}
