using CS2SKINAppWeb.Models;

namespace CS2SKINAppWeb.Services;

public interface ISkinsService
{
    IList<Skins> ObterTodos();
    Skins Obter(int id);
    void Incluir(Skins skins);
    void Alterar(Skins skins);
    void Excluir(int id);
}
