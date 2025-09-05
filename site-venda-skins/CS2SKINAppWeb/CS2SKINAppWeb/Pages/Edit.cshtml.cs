using CS2SKINAppWeb.Models;
using CS2SKINAppWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;

namespace CS2SKINAppWeb.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private ISkinsService _service;
        private readonly IToastNotification _toastNotification;
        public EditModel(ISkinsService skinsService, IToastNotification toastNotification)
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

        public void OnGet(int id)
            => SKIN = _service.Obter(id);
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Alterar(SKIN);
            // Exibir uma mensagem de sucesso usando o NToastNotify
            _toastNotification.AddSuccessToastMessage("Operação de Alteração bem-sucedida!");

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete()
        {
            _service.Excluir(SKIN.SkinsID);

            // Exibir uma mensagem de sucesso usando o NToastNotify
            _toastNotification.AddSuccessToastMessage("Operação de Exclusão bem-sucedida!");
            return RedirectToPage("/Index");
        
        }
    }
}
