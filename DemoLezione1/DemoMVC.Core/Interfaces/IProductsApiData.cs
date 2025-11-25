using DemoMVC.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMVC.Core.Interfaces;

public interface IProductsApiData
{
    Task<ProdottoDTO?> GetById(int id);

    Task<IEnumerable<ProdottoDTO>?> GetAll();

    Task Create(ProdottoCreaDTO prodottoCreaDTO);

    Task Delete(int id);

    Task Update(ProdottoModificaDTO prodottoModificaDTO);
}
