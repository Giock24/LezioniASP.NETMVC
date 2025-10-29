using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Core.ViewModel;

public class MenuViewModel
{
    public string Saluto { get; set; } = "Buongiorno";
    public string NomeCognomeUltimoInserito { get; set; } = "";
    public string NumeroTotaleStudenti { get; set; } = "";
}
