using DemoMVC.Core.Interfaces;

namespace DemoMVC.Core.Entities;

public class Teacher : IGenericEntity<int>
{
    public int Id { get; set; }
    public string Nome { get; set; } = String.Empty;
    public string Cognome { get; set; } = String.Empty;
    public string Codice { get; set; } = String.Empty;
    public string Materia { get; set; } = String.Empty;
}
