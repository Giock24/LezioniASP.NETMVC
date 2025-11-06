using DemoMVC.Core.Entities;
using DemoMVC.Core.Interfaces;

namespace DemoMVC.Controllers;

public class FattureController : BaseCRUDController<Fattura, Guid>
{

    public FattureController(IGenericData<Fattura, Guid> repository) : base(repository)
    {
    }


}
