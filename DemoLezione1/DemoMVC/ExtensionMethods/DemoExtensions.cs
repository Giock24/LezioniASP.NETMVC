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

    public static List<CategoriaDTO> ConvertiInListaDTO(this List<Category> categories)
    {
        var categorieDTO = new List<CategoriaDTO>();

        foreach (var category in categories)
        {
            var categoriaDTO = new CategoriaDTO();
            categoriaDTO.Id = category.CategoryId;
            categoriaDTO.Nome = category.CategoryName;
            categoriaDTO.Descrizione = category.Description;
            categorieDTO.Add(categoriaDTO);
        }

        return categorieDTO;
    }
}
