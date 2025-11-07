using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Core.ViewModel;

public class DashboardIndexViewModel
{
    public int NumeroCategorie { get; set; }

    public int NumeroProdotti { get; set; }

    public string UltimaCategoriaCreata { get; set; } = "";
}
