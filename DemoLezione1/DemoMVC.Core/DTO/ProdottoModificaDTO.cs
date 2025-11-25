namespace DemoMVC.Core.DTO;

public class ProdottoModificaDTO
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public int? FornitoreId { get; set; }

    public int? CategoriaId { get; set; }

    public decimal? PrezzoUnitario { get; set; }
}
