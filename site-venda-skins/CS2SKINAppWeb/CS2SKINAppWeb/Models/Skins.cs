using System.ComponentModel.DataAnnotations;

namespace CS2SKINAppWeb.Models;

public class Skins
{
    public int SkinsID {  get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Nome' obrigatório.")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Campo 'Nome' deve conter entre 6 e 50 caracteres")]
    public string Nome { get; set; }

    public string NomeSlug => Nome.ToLower().Replace("|", "★").ToLower().Replace(" ", "-");

    [Display(Name = "Descrição")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Descrição' obrigatório.")]
    [StringLength(550, MinimumLength = 50, ErrorMessage = "Campo 'NoDescriçãome' deve conter entre 50 e 100 caracteres")]
    public string Descricao { get; set; }

    [Display(Name = "Caminho da Imagem")]

    public string ImagemUri { get; set; }

    [Display(Name = "Preço")]
    [Required(ErrorMessage = "Campo 'Preço' obrigatório.")]
    [DataType(DataType.Currency)]
    public double Preco { get; set; }

    [Display(Name = "Data Publicada")]
    [Required(ErrorMessage = "Campo 'Data Publicada' obrigatório.")]
    public DateTime DataCadastro { get; set; }

    [Display(Name = "Raridade")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Raridade' obrigatório.")]
    public string Raridade { get; set; }

    [Display(Name = "Condição")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Condição' obrigatório.")]
    public string Condicao { get; set; }

    [Display(Name = "Float")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Float' obrigatório.")]
    public string Float { get; set; }

    [Display(Name = "Pattern")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Campo 'Pattern' obrigatório.")]
    public int Pattern { get; set; }
}
