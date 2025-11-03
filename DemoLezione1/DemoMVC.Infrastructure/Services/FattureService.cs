using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;

namespace DemoMVC.Infrastructure.Services;

public class FattureService : IGenericData<Fattura, Guid>
{
    private static List<Fattura> list = new(){new Fattura
            {
                Id = Guid.NewGuid(),
                Data = DateTime.Today,
                CodiceDocumento = "C1ht"
            },
            new Fattura
            {
                Id = Guid.NewGuid(),
                Data = DateTime.Today,
                CodiceDocumento = "APPX1"
            }
        };

    public async Task CreateAsync(Fattura item)
    {
        await Task.Delay(1000);

        item.Id = Guid.NewGuid();

        list.Add(item);
    }

    public async Task DeleteAsync(Guid id)
    {
        await Task.Delay(1000);

        var fattura = list.Find(x => x.Id == id);

        if (fattura != null)
        {
            list.Remove(fattura);
        }
    }

    public async Task EditAsync(Fattura item)
    {
        await Task.Delay(1000);

        var fattura = list.Find(x => x.Id == item.Id);

        if (fattura != null)
        {
            fattura.Data = item.Data;
            fattura.CodiceDocumento = item.CodiceDocumento;
        }
    }

    public async Task<IEnumerable<Fattura>> GetAllAsync()
    {
        await Task.Delay(1000);

        return list;
    }

    public async Task<Fattura?> GetByIdAsync(Guid id)
    {
        await Task.Delay(1000);

        return list.Find(x => x.Id == id);
    }
}
