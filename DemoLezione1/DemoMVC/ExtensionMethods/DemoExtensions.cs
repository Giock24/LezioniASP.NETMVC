using DemoMVC.Core.DTO;
using DemoMVC.Data.Models;

namespace DemoMVC.ExtensionMethods;

public static class DemoExtensions
{
    public static Category ConvertToCategory(this CategoriaCreaDTO categoriaCreaDTO)
    {
        var category = new Category();

        category.CategoryName = categoriaCreaDTO.Nome;
        category.Description = categoriaCreaDTO.Descrizione;

        return category;
    }
    public static CategoriaModificaDTO ConvertToCategoriaEditDTO(this Category category)
    {
        var categoriaModificaDTO = new CategoriaModificaDTO();

        categoriaModificaDTO.Id = category.CategoryId;
        categoriaModificaDTO.Nome = category.CategoryName;
        categoriaModificaDTO.Descrizione = category.Description;

        return categoriaModificaDTO;
    }
}
