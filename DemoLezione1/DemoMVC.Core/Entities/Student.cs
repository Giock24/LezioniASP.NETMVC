using DemoMVC.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Core.Entities;

public class Student:IGenericEntity<int>
{
    public int Id { get; set; }
    [Required(ErrorMessage ="Matricola obbligatoria")]
    public required string Matricola { get; set; }
    public string? Nome { get; set; }
    public string? Cognome { get; set; }
    public DateTime? DataDiNascita { get; set; }
    public string? Id_CAP { get; set; }
    public string? Indirizzo { get; set; }
    public string? NumeroCivico { get; set; }
    public required string CodiceFiscale { get; set; }
}
