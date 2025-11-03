
using DemoMVC.Core.Interfaces;

namespace DemoMVC.Core.Entities;

public class EntityBase : IGenericEntity<int>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get ; set; }
}
