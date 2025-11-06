using DemoMVC.Core.Interfaces;

namespace DemoMVC.Core.Entities;

public class Teacher : IEntity<int>
{
    public int Id { get; set; }
    public string Codice { get; set; } = "";
    public string Materia { get; set; } = "";
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
}
