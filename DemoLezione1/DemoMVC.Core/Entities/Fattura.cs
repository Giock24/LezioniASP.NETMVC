using DemoMVC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Core.Entities;

public class Fattura : IEntity<Guid>
{
    public Guid Id { get; set; }

    public string? CodiceDocumento { get; set; }

    public DateTime Data {  get; set; } = DateTime.Today;
}

class ChiaveSpeciale
{
    public int Id1 { get; set; }

    public int Id2 { get; set; }
}

class EntitaSpeciale : IEntity<ChiaveSpeciale>
{
    public ChiaveSpeciale Id { get; set; }
}