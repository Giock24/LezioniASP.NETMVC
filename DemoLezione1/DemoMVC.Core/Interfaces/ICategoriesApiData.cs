using DemoMVC.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMVC.Core.Interfaces;

public interface ICategoriesApiData
{
    Task<IEnumerable<CategoriaDTO>?> GetAll();
}
