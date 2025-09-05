using CS2SKINAppWeb.Data;
using CS2SKINAppWeb.Models;

namespace CS2SKINAppWeb.Services.Data;

public class SkinsService : ISkinsService
{
    private SkinsDbContext _context;

    public SkinsService(SkinsDbContext context)
    {
        _context = context;
    }

    public void Alterar(Skins skins)
    {
        var skinsEncontrado = Obter(skins.SkinsID);
        skinsEncontrado.Nome = skins.Nome;
        skinsEncontrado.Preco = skins.Preco;
        skinsEncontrado.ImagemUri = skins.ImagemUri;
        skinsEncontrado.Raridade = skins.Raridade;
        skinsEncontrado.Condicao = skins.Condicao;
        skinsEncontrado.Float = skins.Float;
        skinsEncontrado.Pattern = skins.Pattern;
        skinsEncontrado.Descricao = skins.Descricao;
        skinsEncontrado.DataCadastro = skins.DataCadastro;
        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var skinsEncontrado = Obter(id);
        _context.Skins.Remove(skinsEncontrado);
        _context.SaveChanges();

    }

    public void Incluir(Skins skins)
    {
        _context.Skins.Add(skins);
        _context.SaveChanges();
    }

    public Skins Obter(int id)
    {
        return _context.Skins.SingleOrDefault(item => item.SkinsID == id);
    }

    public IList<Skins> ObterTodos()
    {
        return _context.Skins.ToList(); 
    }
}
