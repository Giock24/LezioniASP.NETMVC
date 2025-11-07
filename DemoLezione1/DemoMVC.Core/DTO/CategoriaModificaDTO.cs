using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Core.DTO;

public class CategoriaModificaDTO
{
    public int Id { get; set; }

    [MaxLength(15, ErrorMessage = "La categoria può essere lunga al massimo 15 caratteri")]
    public string Nome { get; set; } = "No nome";

    public string? Descrizione { get; set; }
}
