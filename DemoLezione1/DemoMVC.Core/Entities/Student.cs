using DemoMVC.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Core.Entities;

public class Student: EntityBase 
{
    public required string Matricola { get; set; }
    public DateTime? DataDiNascita { get; set; }
    public string? Id_CAP { get; set; }
    public string? Indirizzo { get; set; }
    public string? NumeroCivico { get; set; }
    public required string CodiceFiscale { get; set; }
}
