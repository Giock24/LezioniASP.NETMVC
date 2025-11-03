using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.Core.Interfaces;

public interface IGenericEntity<T>
{
    T Id { get; set; }

    string? Nome { get; set; }

    string? Cognome { get; set; }
}
