using DemoMVC.Core.Interfaces;

namespace DemoMVC.Core.Entities;

public class Teacher : EntityBase
{
    public string Codice { get; set; } = "";
    public string Materia { get; set; } = "";
}
