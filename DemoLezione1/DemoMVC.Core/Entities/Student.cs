using DemoMVC.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Core.Entities;

public class Student: EntityBase 
{
    public string? Matricola { get; set; }
    public DateTime? DataDiNascita { get; set; }
    public string? Id_CAP { get; set; }
    public string? Indirizzo { get; set; }
    public string? NumeroCivico { get; set; }
    public string? CodiceFiscale { get; set; }
}
