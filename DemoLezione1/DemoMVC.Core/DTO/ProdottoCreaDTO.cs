namespace DemoMVC.Core.DTO;

public class ProdottoCreaDTO
{
    public string Nome { get; set; }

    public int? FornitoreId { get; set; }

    public int? CategoriaId { get; set; }

    public decimal? PrezzoUnitario { get; set; }
}
